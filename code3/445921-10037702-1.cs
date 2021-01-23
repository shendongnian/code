    List<MyClass> transformed = new List<MyClass>
    foreach(var item in data)
    {
        var sunday = new MyClass{Date = item.WKENDDATE.AddDays(-6), Val = item.SUNDAY};
        var monday = new MyClass{Date = item.WKENDDATE.AddDays(-5), Val = item.MONDAY};
        ...
        transformed.Add(sunday);
        transformed.Add(monday);
        ...
    }
