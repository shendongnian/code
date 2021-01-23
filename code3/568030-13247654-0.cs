        private static void SetAddRemoveProgramsIcon()
        {
            //only run if deployed 
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    Assembly code = Assembly.GetExecutingAssembly();
                    AssemblyDescriptionAttribute asdescription =
                        (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                   // string assemblyDescription = asdescription.Description;
                    //the icon is included in this program
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "hl772-2.ico");
                    if (!File.Exists(iconSourcePath))
                        return;
                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == "admin")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
                }
            }
        }
