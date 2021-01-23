    private static void UpdateGPO(string machinename)
            {
               try
                {
                    ConnectionOptions connectionOptions = new ConnectionOptions();
    
                    connectionOptions.Username = @"Domain\Administrator";
                    connectionOptions.Password = "password";
                    connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
    
                    ManagementScope scope = new ManagementScope("\\\\" + machinename + "\\root\\CIMV2", connectionOptions);
    
                    scope.Connect();
    
                    ManagementClass clas = new ManagementClass(scope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
    
                    ManagementBaseObject inparams = clas.GetMethodParameters("Create");
    
                    inparams["CommandLine"] = "GPUpdate /force";
    
                    ManagementBaseObject outparam = clas.InvokeMethod("Create", inparams, null);
                }
                catch (Exception ex)
                {
    
                }
            }
