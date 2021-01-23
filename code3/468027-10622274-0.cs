    List<string> propNames = new List<string>();
    
    foreach (var info in atype.GetType().GetProperties())
    {
       propNames.Add(info.Name);
    }
