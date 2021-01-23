    var mi = objType.GetProperties();
    for (int i = 0; i < mi.Length; i++)
    {
        var type = mi[i].PropertyType;
        //Check for string array
        if (type.IsArray && type.GetElementType() == typeof(string))
        {
        }
    }
    
