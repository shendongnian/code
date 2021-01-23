    public IEnumerable<string> GetKey (Func<string, bool> condition)
    {
        return HttpContext.Current.Items.Keys
            .OfType<string>()
            .Where(condition);
    }
