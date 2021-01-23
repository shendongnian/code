    foreach(object s in St)
    {
       Type type = s.GetType();
       PropertyInfo property = type.GetProperty("Name");
       string name= (string )property.GetValue(s, null);
    }
