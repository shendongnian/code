public Task<string> GetToken()
{
  string mockToken = Guid.NewGuid().ToString(); 
  return Task.FromResult(mockToken);
}
# B. async and `await Task.FromResult`
public async Task<string> GetToken()
{
  string mockToken = Guid.NewGuid().ToString(); 
  return await Task.FromResult(mockToken);
}
# C. `Task.Run`
public string GetTokenNonAsync() => Guid.NewGuid().ToString();
public async Task<string> GetTokenAsync() => await Task.Run(GetTokenNonAsync);
----
# Note on exception behaviour
As @patrick-roberts rightly points out dropping the `async` changes the exception dynamics. 
*In this case it doesn't matter since `Guid.NewGuid().ToString();` does not throw.*
Here's a little demo which shows the difference.
public Task<string> GetToken1WithoutAsync() => throw new Exception("Ex1!");
public async Task<string> GetToken2WithAsync() => throw new Exception("Ex2!");
public string GetToken3Throws() => throw new Exception("Ex3!");
public async Task<string> GetToken3WithAsync() => await Task.Run(GetToken3Throws);
        
public static async Task Main(string[] args)
{
    var p = new Program();
    
    try { var task1 = p.GetToken1WithoutAsync(); } 
    catch( Exception ) { Console.WriteLine("Throws before await.");};
    var task2 = p.GetToken2WithAsync(); // Does not throw;
    try { var token2 = await task2; } 
    catch( Exception ) { Console.WriteLine("Throws on await.");};
    var task3 = p.GetToken3WithAsync(); // Does not throw;
    try { var token3 = await task2; } 
    catch( Exception ) { Console.WriteLine("Throws on await.");};
}
// .NETCoreApp,Version=v3.0
Throws before await.
Throws on await.
Throws on await.
