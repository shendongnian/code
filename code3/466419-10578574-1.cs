    using (new Impersonator("user", "domain", "pass"))
    {
       Process[] allRemoteProcesses = Process.GetProcesses("myRemoteComputer");
       // Rest of code...
    }
