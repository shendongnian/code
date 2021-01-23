    Dictionary<string, object> values = ...
    List<MyObject> objects = ...
    
    foreach(var item in objects)
    {
        item.Value = values[item.Key];
    
        // process your data
    
        item.TextBox = item.Value.ToString();
    }
