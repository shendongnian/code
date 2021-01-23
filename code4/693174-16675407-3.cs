    { Name = "Dave Et", Id = 1 }
    { Name = "Danial Maze", Id = 2 }
    { Name = "Danial", Id = 3 }
----------
    static string LongestCommonPrefix(IEnumerable<string> xs)
    {
        return new string(xs
            .Transpose()
            .TakeWhile(s => s.All(d => d == s.First()))
            .Select(s => s.First())
            .ToArray());
    }
