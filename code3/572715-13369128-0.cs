    static void MainT(string[] args)
    {
        List<int> foo = new List<int> { 1, 2, 3 };
        var myResult = MyTest<int>(foo);
    }
    private static List<int> MyTest<T>(List<T> input) where T : IEquatable<int>
    {
        List<int> bar = new List<int> { 2, 3, 4 };
        return bar.Where(b => input.Any(i => i.Equals(b))).ToList();
    }
