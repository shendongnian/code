    public IEnumerable<IEnumerable<IPropertyData>> Get(string query)
    {
        var searcher = new ManagementObjectSearcher(query);
        var results = searcher.Get();
        return results.Cast<ManagementBaseObject>()
            .Select(item => item.Cast<PropertyData>()
                                .Select(x => (IPropertyData)
                                             new PropertyDataImpl(x.Name, x.Value));
    }
