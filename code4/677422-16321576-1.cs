    using System.Deployment.Application;
    using Microsoft.Win32;
    //Call this method as soon as possible
        private static void SetAddRemoveProgramsIcon()
        {
            //Only execute on a first run after first install or after update
            if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    // Set the name of the application exe file - make sure to include `,0` at the end
                    // Does not work for click once applications as far as I could figure out... Note, this will probably work
                    // when run from VS, but not when deployed.
                    //string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "example.exe,0");
                    // Reverted to using this instead (note this will probably not work when run from VS, but will work on deploy.
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "example.ico");
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
                        Console.WriteLine(myValue.ToString());
                        // Set this to the display name of the application. If you are not sure, browse to the registry directory and check.
                        if (myValue != null && myValue.ToString() == "Example Application")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch(Exception mye)
                {
                    MessageBox.Show("We could not properly setup the application icons. Please notify your software vendor of this error.\r\n" + mye.ToString());
                }
            }
        }
