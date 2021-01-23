    var ranges = new[]
    {
        Enumerable.Range(0, 20),
        Enumerable.Range(21, 30),
        Enumerable.Range(31, 40),
        Enumerable.Range(41, 50),
        // ...
    };
    var number = 44;
    for (int i = 0; i < ranges.Length; i++)
    {
        var range = ranges[i];
        if (range.Contains(number))
        {
            var theIndex = i + 1;
            // do something with theIndex
        }
    }
