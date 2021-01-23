    public static IEnumerable<int> MyMethod()
    {
        return new List<int>() { 1, 2, 3 };
    }
    ....
    public static IEnumerable<int> MyMethod()
    {
        return new int[] {1, 2, 3};
    }
