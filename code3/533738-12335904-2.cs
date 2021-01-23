    public IEnumerable<long> TotalItems
    {
        get
        {
            // this automatically discovers properties of type List<long>
            // and grabs their values
            var properties = from property in GetType().GetProperties()
                        where typeof(List<long>).IsAssignableFrom(property.PropertyType)
                        select (IEnumerable<long>)property.GetValue(this, null);
            foreach (var property in properties)
            {
                foreach (var value in property)
                    yield return value;
            }
        }
    }
