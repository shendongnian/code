    public IEnumerable<string> GetKey (Func<string, bool> condition)
    {
        return HttpContext.Current.Items
            .Cast<DictionaryEntry>()
            .Where(e => e.Key is string && 
                        e.Value is string && 
                        condition(e.Key as string))
            .Select(e => e.Value as string);
    }
