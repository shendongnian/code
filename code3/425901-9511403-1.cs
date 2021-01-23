    public void ExportToExcel<T>(IEnumerable<T> items)
    {
        var properties = typeof(T).GetProperties();
        foreach(var item in items)
        {
            foreach(var property in properties)
            {
                var value = property.GetValue(item, null);
                // Do something else with the property's value
            }
        }
    }
