    //short example string - may contain 1000's     
    string newstr = ...;
    string[] keysAndValues = newstr.Split(':');
    var mydictionary = new Dictionary<string, List<string>>(keysAndValues.Length);
    foreach (string item in keysAndValues)     
    {         
        List<string> list = new List<string>(item.Split(','));         
        mydictionary.Add(list[0], list);             
    } 
