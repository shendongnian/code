    public static string ConvertToCsv<T>(IEnumerable<T> items)
    {
        foreach (T item in items.Where(i => i.GetType().Module.ScopeName.Equals("CommonLanguageRuntimeLibrary")))
        {
        }
    }
