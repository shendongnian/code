       using Microsoft.Win32;
        public static string GetRegistry()
        {
            string registryValue = string.Empty;
            RegistryKey localKey = null;
            if (Environment.Is64BitOperatingSystem)
            {
                localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            }
            try
            {
                localKey = localKey.OpenSubKey(@"Software\\MyKey");
                registryValue = localKey.GetValue("TestKey").ToString();
            }
            catch (NullReferenceException nre)
            {
            
            }
            return registryValue;
        }
