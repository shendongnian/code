    var d = new Dictionary<string, int>
                {
                    {"A", 4},
                    {"B", 44},
                    {"bye", 56},
                    {"C", 99},
                    {"D", 46},
                    {"6672", 0}
                };
    var l = new List<string> {"A", "C", "D"};
    d.RemoveAll(l);
    foreach (var kvp in d)
    {
        Console.WriteLine(kvp.Key + ": " + kvp.Value);
    }
