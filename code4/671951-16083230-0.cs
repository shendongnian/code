    public IDictionary<string, IEnumerable<string>> Name2Addresses
    {
        get
        {
            return name2Addresses.ToDictionary<string, IEnumerable<string>>(
                kvp => kvp.Key,
                kvp => kvp.Value.AsEnumerable());
        }
    }
