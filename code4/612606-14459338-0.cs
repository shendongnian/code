    string[] values = { "1", "2", "3a","4" };
    int i = int.MinValue;
    List<int> output = values.Where(s => int.TryParse(s, out i))
                             .Select(s => i)
                             .ToList();
