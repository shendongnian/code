    public static class EnvironmentExtension
    {
        public static string ContractEnvironmentVariables(string path)
        {
            path = Path.GetFullPath(path);
            DictionaryEntry currentvar = new DictionaryEntry("","");
            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                if (path.Contains(item.Value.ToString()) && item.Value.ToString().Length > currentvar.Value.ToString().Length)
                {
                    currentvar = item;
                }
            }
            return path.Replace(currentvar.Value.ToString(), "%" + currentvar.Key.ToString() + "%");
        }
    }
