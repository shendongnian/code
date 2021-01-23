    var max = 100;
    var range = Enumerable.Range(1, max);
    var intsNotInList = range.Except(list);
    foreach (var i in intsNotInList)
    {
        var obj = new MyObject() 
        {
            Name = i.ToString(),
            Order = i,
        };
        list.Add(obj);
    }
