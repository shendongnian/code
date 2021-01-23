    using Microsoft.Win32;
    namespace SimpleSettings
    {
    public class Settings
    {
        private static string RegistrySubKey = @"SOFTWARE\BlahCompany\BlahApp";
        public static void write(string setting, string value)
        {
            using (RegistryKey registryView = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            using (RegistryKey registryCreate = registryView.CreateSubKey(RegistrySubKey))
            using (RegistryKey registryKey = registryView.OpenSubKey(RegistrySubKey, true))
            {
                registryKey.SetValue(setting, value, RegistryValueKind.String);
            }        
        }
        public static string read(string setting, string def)
        {
            string output = string.Empty;
            using (RegistryKey registryView = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            using (RegistryKey registryCreate = registryView.CreateSubKey(RegistrySubKey))
            using (RegistryKey registryKey = registryView.OpenSubKey(RegistrySubKey, false))
            {
                // Read the registry, but if it is blank, update the registry and return the default.
                output = (string)registryKey.GetValue(setting, string.Empty);
                if (string.IsNullOrWhiteSpace(output))
                {
                    output = def;
                    write(setting, def);
                }
            }
            return output;
        }
    }
    }
