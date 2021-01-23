     private Dictionary<string, object> GetRegistrySubKeys()
        {
            Dictionary<string, object>  valuesBynames   = new Dictionary<string, object>();
            const string REGISTRY_ROOT = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";
            //Here I'm looking under LocalMachine. You can replace it with Registry.CurrentUser for current user...
            using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT))
            {
            if (rootKey != null)
            {
                string[] valueNames = rootKey.GetValueNames();
                foreach (string currSubKey in valueNames)
                {
                    object value = rootKey.GetValue(currSubKey);
                    valuesBynames.Add(currSubKey, value);
                }
            }
            rootKey.Close();
            }
            return valuesBynames;
        }
