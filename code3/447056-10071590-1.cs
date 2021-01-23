    bool b;
    b = 7.In(3, 5, 6, 7, 8); // true
    b = "hi".In("", "10", "hi", "Hello"); // true
    b = "hi".In("", "10", "Hi", "Hello"); // false
    b = "hi".In((s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase), "", "10", "Hi"); // true
    var tuples = new List<Tuple<int, string>>();
    for (var i = 0; i < 10; i++)
    {
        tuples.Add(Tuple.Create(i, ""));
    }
    var tuple = Tuple.Create(3, "");
    b = tuple.In(tup => tup.Item1, tuples); // true
