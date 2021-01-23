      public static class ProgramHelper
        {
            public static bool IsProgramInstalled(string displayName, bool x86Platform)
            {
                string uninstallKey = x86Platform
                                          ? @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
                                          : @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
    
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
                {
                    if(rk != null)
                        foreach (string skName in rk.GetSubKeyNames())
                        {
                            using (RegistryKey sk = rk.OpenSubKey(skName))
                            {
                                if (sk != null && sk.GetValue("DisplayName") != null &&
                                    sk.GetValue("DisplayName").ToString().ToUpper().Equals(displayName.ToUpper()))
                                {
                                    return true;
                                }
    
                            }
                        }
                }
                return false;
            }
        }
