      using Microsoft.Win32;
        public static string GetRegistry()
        {
            string registryValue = string.Empty;
            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                localKey = localKey.OpenSubKey(@"Software\\MyKey");
                registryValue = localKey.GetValue("TestKey").ToString();
            }
            else
            {
                RegistryKey localKey32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
                localKey32 = localKey32.OpenSubKey(@"Software\\MyKey");
                registryValue = localKey32.GetValue("TestKey").ToString();
            }
            return registryValue;
        }
