    public class RegistryExample 
    {
        public static void Main()
        {
            const string rootUser = "HKEY_CURRENT_USER";
            const string subkey = "RegistryExample";
            const string keyName = String.Format("{0}\\{1}, userRoot, subkey);
            Registry.SetValue(keyName, "MyRegistryValue", 1234);
        }
    }
