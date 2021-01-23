    PopulateType(Object obj)
    {
        //A dictionary of values to set for found properties
        Dictionary<String, Object> defaultValues = new Dictionary<String, Object>();
        defaultValues.Add("BirthPlace", "Amercia");
        for (var defaultValue in defaultValues)
        {
            //Here is an example that just set BirthPlace to a known value Amercia
            PropertyInfo prop = obj.GetType().GetProperty(defaultValue.Key, BindingFlags.Public | BindingFlags.Instance);
            if(null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, defaultValue.Value, null);
            }
        }
    }
