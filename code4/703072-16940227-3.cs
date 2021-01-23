        public static Dictionary<string, string> ListPrograms()
        {
            Dictionary<string, string> Apps = new Dictionary<string, string>();
            string registryKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    var key1 = key.GetSubKeyNames();
                    foreach (var z in key1.Select(s => key.OpenSubKey(s))
                        .Where(b => b != null && b.GetValue("DisplayName") != null && b.GetValue("UninstallString") != null).Select(b => new
                        {
                            DisplayName = b.GetValue("DisplayName").ToString(),
                            RegistryKey = b.GetValue("UninstallString").ToString()
                        }).Where(z => !Apps.ContainsKey(z.RegistryKey)))
                    {
                        Apps.Add(z.RegistryKey, z.DisplayName);
                    }
                }
            }
            return Apps;
        }
