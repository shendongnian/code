    string sql = string.Format("SELECT * From Win32_Service WHERE Name = {0}", string.Join(" OR Name =", server.TargetServices));
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(server.Services.Scope, new ObjectQuery()
                    {
                        QueryString = sql
                    });
                foreach (ManagementObject service in searcher.Get())
                {
                    service.InvokeMethod("StartService", null);
                    //My Target Services
                }
