    private class PropertyItem
    {
        public PropertyInfo Property { get; set; }
        public List<object> PossibleValues { get; set; }
        public int CurrentIndex { get; set; }
        public int Count { get; set; }
    }
    
    public IEnumerable<T> GenerateCombinations<T>() where T : new()
    {
        return GenerateCombinations(typeof(T)).Cast<T>();
    }
    
    public IEnumerable<object> GenerateCombinations(Type type)
    {
        // Collect nessecery information
        var constructor = type.GetConstructor(Type.EmptyTypes);
        var properties =
            (
                from p in type.GetProperties()
                let values = p.GetCustomAttributes(typeof(CombinationsAttribute), true)
                    .Cast<CombinationsAttribute>()
                    .SelectMany(a => a.PossibleValues)
                    .ToList()
                where values.Count > 0
                select new PropertyItem
                {
                    Property = p,
                    PossibleValues = values,
                    CurrentIndex = 0,
                    Count = values.Count,
                }
            )
            .ToList();
        
        // Generate each possible object
        bool isDone;
        do
        {
            var item = constructor.Invoke(new object[0]);
            foreach (var prop in properties)
            {
                prop.Property.SetValue(item, prop.PossibleValues[prop.CurrentIndex]);
            }
            yield return item;
            
            isDone = true;
            for (int i = 0; i < properties.Count; i++)
            {
                var prop = properties[i];
                if (prop.CurrentIndex == prop.Count - 1)
                {
                    prop.CurrentIndex = 0;
                }
                else
                {
                    prop.CurrentIndex++;;
                    isDone = false;
                    break;
                }
            }
        }
        while (!isDone);
    }
<!-- -->
