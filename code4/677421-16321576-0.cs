    using System.Deployment.Application;
    using Microsoft.Win32;
    //Call this method in the main form load method
        private static void SetAddRemoveProgramsIcon()
        {
            //Only execute on a first run (Not currently working)
            //if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
            //{
                try
                {
                    // Set the name of the application exe file - make sure to include `,0` at the end
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "example.exe,0");
                    if (!File.Exists(iconSourcePath))
                        return;
                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        Console.WriteLine(myValue.ToString());
                        // Set this to the display name of the application. If you are not sure, browse to the registry directory and check.
                        if (myValue != null && myValue.ToString() == "Example Application")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception mye) { //Do what you want with this }
            //}
        }
