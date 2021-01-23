    var list = new List<MyClass>(keyValuePair.Value.Count);
    foreach (MyClass eData in keyValuePair.Value)
    {
        string weight;
        ............
        //Here comes some calculations
        ............
        if (weight == 0d)
        {
            list.Insert(0, eData);
        }
        else
        {
            list.Add(eData);
        }
    }
    foreach (var eData in list)
        // render eData into table
