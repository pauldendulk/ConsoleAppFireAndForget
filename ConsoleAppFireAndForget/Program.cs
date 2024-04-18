// CASE 1
Console.WriteLine("Case 1: Task.Run does not block the main thread. No problem if there is no exception.");
try
{
    _ = Task.Run(MethodCase1Async);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 1: Waiting for fire and forget method.");
Console.ReadLine();

// CASE 2
Console.WriteLine("Case 2: _ = does not block the main thread. Same behavior. Simpler, so better, but ...");
try
{
    _ = MethodCase2Async();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 2: Waiting for fire and forget method.");
Console.ReadLine();

// CASE 3
Console.WriteLine("Case 3: Task.Run eats the exception. This is a problem.");
try
{
    _ = Task.Run(MethodCase3Async);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 3: Waiting but nothing happens.");
Console.ReadLine();

// CASE 4
Console.WriteLine("Case 4: _ = also eats the exception. This is still a problem.");
try
{
    _ = MethodCase4Async();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 4: Waiting but nothing happens.");
Console.ReadLine();

// CASE 5
Console.WriteLine("Case 5: await Task.Run shows the exception but method is not fire and forget.");
try
{
    await Task.Run(MethodCase5Async);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 5: Waiting for key press.");
Console.ReadLine();

// CASE 6
Console.WriteLine("Case 6: await _ = shows the exceptio but method is not fire and forget.n. ");
try
{
    await MethodCase6Async();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 6: Waiting for key press.");
Console.ReadLine();

// CASE 7
Console.WriteLine("Case 7: _ = for fire and forget with try-catch in method.");
try
{
    _ = MethodCase7Async();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Case 7: Waiting for exception.");
Console.ReadLine();

static async Task MethodCase1Async()
{
    await Task.Delay(1000);
    Console.WriteLine("Case 1: Delayed async method");
}

static async Task MethodCase2Async()
{
    await Task.Delay(1000);
    Console.WriteLine("Case 2: Delayed async method");
}

static async Task MethodCase3Async()
{
    await Task.Delay(1000);
    throw new Exception("Case 3: Exception from async method. This won't show in the console.");
}

static async Task MethodCase4Async()
{
    await Task.Delay(1000);
    throw new Exception("Case 4: Exception from async method. This won't show in the console.");
}

static async Task MethodCase5Async()
{
    await Task.Delay(1000);
    throw new Exception("Case 5: Exception from async method.");
}

static async Task MethodCase6Async()
{
    await Task.Delay(1000);
    throw new Exception("Case 6: Exception from async method.");
}

static async Task MethodCase7Async()
{
    try
    {
        await Task.Delay(1000);
        throw new Exception("Case 7: Exception from async method.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
