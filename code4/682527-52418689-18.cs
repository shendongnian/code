        public static async Task<bool> SearchSubKeysForValue(RegistryKey regKey, string valueName, string searchedValue, StringComparison strComparison = StringComparison.Ordinal)
        {
            bool result = false;
            string[] subKeysNames = regKey.GetSubKeyNames();
            List<Task<bool>> tasks = new List<Task<bool>>();
            for (int i = 0; i < subKeysNames.Length - 1; i++)
            {
                //We have to save current value for i, because we cannot use it in async task due to changed values for it during foor loop
                string subKeyName = subKeysNames[i];
                tasks.Add(Task.Run(() =>
                {
                    string value = regKey.OpenSubKey(subKeyName)?.GetValue(valueName)?.ToString() ?? null;
                    return (value != null && value.IndexOf(searchedValue, strComparison) >= 0);
                }));
            }
            bool[] results = await Task.WhenAll(tasks).ConfigureAwait(false);
            result = results.Contains(true);
            return result;
        }
