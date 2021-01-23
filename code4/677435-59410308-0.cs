      private static void SetAddRemoveProgramsIcon()
            {
    
    
                //Only execute on a first run after first install or after update
                if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {
                    try
                    {
    
                    //Getting path to the installation directory
                    System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly(); 
                    string assemblyLocation = assemblyInfo.Location;
                    Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
                    string ClickOnceLocation = Path.GetDirectoryName(uriCodeBase.LocalPath.ToString());
                
                    string iconSourcePath = Path.Combine(ClickOnceLocation, "youricon.ico");                
                        if (!File.Exists(iconSourcePath))
                        {
                            MessageBox.Show("We could not find the application icon. Please notify your software vendor of this error.");
                            return;
                        }
    
                        RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                        string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                        for (int i = 0; i < mySubKeyNames.Length; i++)
                        {
                            RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                            object myValue = myKey.GetValue("DisplayName");                                            
                            // Set this to the display name of the application. If you are not sure, browse to the registry directory and check.
                            if (myValue != null && myValue.ToString() == "SafeShare Outlook Add-in")
                            {                        
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                                break;
                            }
                        }
                    }
                    catch (System.Exception mye)
                    {
                        MessageBox.Show("We could not properly setup the application icons. Please notify your software vendor of this error.\r\n" + mye.ToString());
                    }
                }
    
                 }
