    public static class EnvironmentExtension
    {
        public static string ContractEnvironmentVariables(string path)
        {
            path = Path.GetFullPath(path).ToUpperInvariant();
            DictionaryEntry currentEntry = new DictionaryEntry("","");
            foreach (object key in Environment.GetEnvironmentVariables().Keys)
            {
                string value = (string)Environment.GetEnvironmentVariables()[key];
                if (path.Contains(value.ToUpperInvariant()) && value.Length > ((string)currentEntry.Value).Length)
                {
                    currentEntry.Key = (string)key;
                    currentEntry.Value = value;
                }
            }
            return path.Replace((string)currentEntry.Value, "%" + (string)currentEntry.Key + "%");
        }
    }
