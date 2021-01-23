    var test = new TestRecord { A = 1, B = 2, C = 3 };
    foreach (var prop in GetSortedProperties<TestRecord>())
    {
        Console.WriteLine(prop.GetValue(test, null));
    }
