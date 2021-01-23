    Type t = Location.GetType();
    PropertyInfo[] properties
    properties = typeof(Location).GetProperties(BindingFlags.Public);
    StringBuilder sb = new StringBuilder()
    foreach (PropertyInfo p in properties)
    {
    	sb.Append(p.Name)
    	sb.Append(p.PropertyType)
    	sb.Append(p.GetValue(null,null))
    }
