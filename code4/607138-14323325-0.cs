    foreach (var prop in properties)
    {
        var obj = prop.GetValue(p, null);
        if (obj is List<x>)
        {
            var list = obj as List<x>;
            // do something with your list
        }
        else
        {
            table.Add(prop.Name, obj);
        }
    }   
