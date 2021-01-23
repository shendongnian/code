    if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
    {
        //Filterme is a method that takes in IEnumerable<IFilterable>
        var filterable = entities.Cast<IFilterable>();
        entities = FilterMe(entities).AsQueryable();
    }
