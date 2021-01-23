    public IEnumerable<string> GetKey (Func<string, bool> condition)
    {
        return
            from k in HttpContext.Current.Items.Keys.OfType<string>()
            where condition(k)
            select k;
    }
