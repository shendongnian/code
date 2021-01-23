     ManagementScope scope = new ManagementScope();    
                try
                {                      
    
                    ConnectionOptions conOptions = new ConnectionOptions();  
    
                    options.Username = "<Provide username>";    
                    options.Password = "<Provide password>";    
                    options.EnablePrivileges = true;    
                    options.Authority = "ntlmdomain:<domianname>";                        
    
                    scope = new ManagementScope(@"\\<IP address/machine name>\root\CIMV2", options);
    
                    scope.Connect();                      
    
                    SelectQuery query = new SelectQuery("SELECT * FROM Win32_OperatingSystem");
    
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    
                    using (ManagementObjectCollection queryCollection = searcher.Get())
                    {    
                        foreach (ManagementObject m in queryCollection)
                        {                            
    
                            Console.WriteLine(string.Format("Computer Name : {0}", m["csname"]));    
                             Console.WriteLine(string.Format("Windows Directory : {0}", m["WindowsDirectory"]));    
                             Console.WriteLine(string.Format("Operating System: {0}", m["Caption"]));    
                             Console.WriteLine(string.Format("Version: {0}", m["Version"]);
    
                             Console.WriteLine(string.Format("Manufacturer : {0}", m["Manufacturer"]));
    
                        }
    
                    }
    
                }    
                
                catch (Exception ex)
                {
                   
    
                }
