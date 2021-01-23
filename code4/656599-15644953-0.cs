    for (int i = 1; i < 6; i++)
    {
        PropertyInfo prop = myObj.GetType().GetProperty(string.Format("property{0}", i);
        if (prop == null) { continue; }
        prop.SetValue(myObj, collection[prop.Name], null);
    }
