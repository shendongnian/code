    // 1. Create your new app domain...
    var newDomain = AppDomain.CreateDomain(...);
                
    // 2. call domain.ExecuteAssembly, passing in this process and the "/initializingappdomain" argument which will cause the process to exit right away
    newDomain.ExecuteAssembly(GetProcessName(), new[] { "/initializingappdomain" });
    
    private static string GetProcessName()
    {
       return System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", ""));
    }
    
    // 3. Use your app domain as you see fit, Assembly.GetEntryAssembly will now return this hosting .net exe.
 
