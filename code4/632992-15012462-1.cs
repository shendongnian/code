    public static IEnumerable<int> Foo(int count, int start, int max)
    {
        return Enumerable.Range(0, count)
            .Select(n => (n + start) % (max + 1));
    }
