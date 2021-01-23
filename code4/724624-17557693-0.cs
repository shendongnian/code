    var list = new List<List<string>>();
    var current = new List<string>();
    list.Add(current);
    
    foreach (string element in example)
    {
        if (element.Equals("-----"))
        {
            current = new List<string>();
            list.Add(current);
        }
        else
        {
            current.Add(element);
        }
    }
    
    if (!current.Any())
    {
        list.Remove(current);
    }
