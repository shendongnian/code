    protected IDictionary<string, string> GetQueryParameters(string queryString)
    {
        var retval = new Dictionary<string, string>();
        foreach (var item in queryString.TrimStart('?').Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries))
        {
            var split = item.Split('=');
            retval.Add(split[0], split[1]);
        }
        return retval;
    }
