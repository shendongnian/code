    [ImportMany(RequiredCreationPolicy=CreationPolicy.NonShared)]
    public IEnumerable<Lazy<MenuItem,IDictionary<string,object>> MenuItems
    {
       set
       {
            var fooMenuItems = value
                .Where(x => x.Metadata["ContextTarget"] == "foo")
                .Select(x => x.Value);
            // attach fooMenuItems to some context menu...
        }
    }
