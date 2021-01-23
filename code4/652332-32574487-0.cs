    public static class InstalledPrograms
        {
          public static List<string> GetInstalledPrograms()
            {
                var result = new List<string>();
                result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry32));
                result.AddRange(GetInstalledProgramsFromRegistry(RegistryView.Registry64));
                result.Sort();
                return result;
            }
            private static string cleanText(string dirtyText)
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 .()+-]");
                string result = rgx.Replace(dirtyText, "");
                return result;
            }
            private static IEnumerable<string> GetInstalledProgramsFromRegistry(RegistryView registryView)
            {
                var result = new List<string>();
                List<string> uninstall = new List<string>();
                uninstall.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                uninstall.Add(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (string registry_key in uninstall)
                {
                   using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView).OpenSubKey(registry_key))
                   {
                        foreach (string subkey_name in key.GetSubKeyNames())
                        {
                            using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                            {
                                if (IsProgramVisible(subkey))
                                {
                                    result.Add(cleanText(subkey.GetValue("DisplayName").ToString()).ToString());
                                }
                            }
                        }
                    }
                    using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView).OpenSubKey(registry_key))
                    {
                        if (key != null)
                        {
                            foreach (string subkey_name in key.GetSubKeyNames())
                            {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                                {
                                    if (IsProgramVisible(subkey))
                                    {
                                        result.Add(cleanText(subkey.GetValue("DisplayName").ToString()).ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            }
