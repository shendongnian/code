    // Registry 'MSIEXEC Guid'
    public void RegistryFix()
    {            
        // Create a Registry Instance.
        RegistryKey rKey = Registry.LocalMachine.OpenSubKey(@"\\SOFTWARE\\Microsoft
            \\Windows\\CurrentVersion\\Uninstall", true);
    
        // Loop Our Instance:
        foreach( string sub in rKey.GetSubKeyNames() )
        {
    
             #region Error Handling for 'Registry MSIEXEC'
    
             try
             {
                 // Locate Boulevard Instance
                 RegistryKey blvd = rKey.OpenSubKey(@"\\SOFTWARE\\Microsoft
                     \\Windows\\CurrentVersion\\Uninstall\\" + sub);
    
                  // Specify Boulevard Display Name String
                  string blvdDisplay = blvd.GetValue("DisplayName").ToString();
    
                  // Search For:
                  if (blvdDisplay.Contains("Boulevard"))
                  {
    
                        // Now Obtain Uninstall String.
                        string blvdUninstall =   blvd.GetValue("UninstallString").ToString().Replace(@"/u", @"/f");
    
                         // Execute
                         Process u = Process.Start(blvdUninstall);
                         u.WaitForExit();
    
                   }
               }
               #endregion
    
             // Unhandled / Null Error
             catch
            {                    
                   // Write Exception:
                   Console.WriteLine("Null Value Detected");
                   throw new Exception("Invalid or Null Registry Value Detected.");
            } 
       }                         
    }
