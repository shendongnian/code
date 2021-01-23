    var dictionary1 = new Dictionary<int, double>();
    dictionary1.Add(1, 40000);
    dictionary1.Add(2, 56000);
    dictionary1.Add(3, 77000);
    dictionary1.Add(4, 80000);
    dictionary1.Add(5, 100000);
    var dictionary2 = new Dictionary<int, double>();
    dictionary2.Add(1, 40000);
    dictionary2.Add(2, 56000);
    dictionary2.Add(3, 77000);
    dictionary2.Add(4, 50000);
    dictionary2.Add(6, 35000);
    foreach (var difference in dictionary1.GetDifferencesFrom(dictionary2))
    {
        Console.WriteLine(
            "Key {0} was {1} but is now {2}",
            difference.Key.ToString(),
            difference.OriginalValue.ToString(),
            difference.NewValue.ToString());
    }
