    public IEnumerable<string> GetKey (Func<string, bool> condition)
    {
        return
            from e HttpContext.Current.Items.Cast<DictionaryEntry>()
            where e.Key is string && 
                  e.Value is string && 
                  condition(e.Key as string)
            select e.Value as string;
    }
