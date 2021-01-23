    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
    {
        if (key != null)
        {
            foreach (string subKeyName in key.GetSubKeyNames())
            {
                using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                {
                    if (subKey == null) continue;
                    var displayName = subKey.GetValue("DisplayName") as string;
                    if (displayName == null || !displayName.Equals("QuickTime")) continue;
                    var version = subKey.GetValue("DisplayVersion");
                    Console.WriteLine(displayName);
                    Console.WriteLine(version);
                }
            }
        }
    }
