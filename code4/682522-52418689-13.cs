        public static async Task<bool> SearchSubKeysForValue(string keyPath, string valueName, string searchedValue, RegistryHive hive, RegistryView view = RegistryView.Default, string remoteMachine = null, StringComparison strComparison = StringComparison.Ordinal)
        {
            bool result = false;
            string[] subKeysNames;
            List<Task<bool>> tasks = new List<Task<bool>>();
            using (RegistryKey regKey = (string.IsNullOrWhiteSpace(remoteMachine))
                        ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view).OpenSubKey(keyPath)
                        : RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteMachine, view).OpenSubKey(keyPath))
            {
                subKeysNames = regKey.GetSubKeyNames();
            }
            for (int i = 0; i < subKeysNames.Length - 1; i++)
            {
                //We have to save current value for i, because we cannot use it in async task due to changed values for it during foor loop
                string subKeyName = subKeysNames[i];
                tasks.Add(Task.Run(() =>
                {
                    using (RegistryKey tempKey = (string.IsNullOrWhiteSpace(remoteMachine))
                        ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view).OpenSubKey(string.Format("{0}\\{1}", keyPath, subKeyName))
                        : RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteMachine, view).OpenSubKey(string.Format("{0}\\{1}",keyPath, subKeyName)))
                    {
                        string value = tempKey.GetValue(valueName)?.ToString() ?? null;
                        return value != null && value.IndexOf(searchedValue, strComparison) >= 0);
                    }
                }));
            }
            bool[] results = await Task.WhenAll(tasks).ConfigureAwait(false);
            result = results.Any(res => res == true);
            return result;
        }
