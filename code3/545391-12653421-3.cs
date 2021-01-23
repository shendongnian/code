    ...
    for (int i = 0; i < stringArray.Length; i++)
    {
        object type = props[i].PropertyType;
        switch(type.ToString())
        {
             case "System.String": props[i].SetValue(m, stringArray[i]); break;
             case "System.DateTime": props[i].SetValue(m, DateTime.Parse(stringArray[i])); break;
             case "System.Boolean": props[i].SetValue(m, stringArray[i].Equals("true", StringComparison.OrdinalIgnoreCase));break;
         }
    }
    ...
