    class CreationDateConvention  : IPropertyConvention
    {
        public CreationDateConvention(string default)
        {
            _default = default;
        }
    
        public void Apply(... instance)
        {
            if (instance.Name == "CreationDate")
                instance.Default(_default)
        }
    }
    // and while configuring
    ...FluentMappings.AddFromAssemblyOf<>().Conventions.Add(new CreationDateConvention(isOracle ? "to_date..." : Datetime.Minvalue.ToString())
