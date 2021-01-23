    static private void UseIE9DocMode()
            {
                RegistryKey key = null;
                try
                {
                    key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                }
                catch (Exception)
                {
                    key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION");
                }
                key.SetValue(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName, 9999, RegistryValueKind.DWord);
                key.Close();
            }
