    foreach (KeyValuePair<string, dynamic> pair in fields) 
    { 
        string type = pair.Key.Split('_')[0]; 
 
        dynamic obj;
        if (!objects.TryGetValue(type, out obj)) 
        { 
            obj = new ExpandoObject(); 
            objects.Add(type, obj); 
        } 
        int location = pair.Key.IndexOf(type + "_"); 
        string key = pair.Key.Remove(location, type.Length + 1); 
        if (pair.Value == null)
            obj.Add(key, ""); 
        else 
            obj.Add(key, pair.Value);            
    } 
