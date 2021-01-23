    foreach(object item in sequence)
    {
        if (item == null) continue;
        foreach(PropertyInfo property in item.GetType().GetProperties())
        {
            // do something with the property
        }
    }
