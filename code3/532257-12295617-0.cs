    foreach(var person in persons)
    {
        List<string> list;
        if(!dict.TryGetValue(person.Key, out list)
        {
            list = new List<string>();
            dict.Add(person.Key, list);
        }
        
        list.Add(person.Data);
    }
