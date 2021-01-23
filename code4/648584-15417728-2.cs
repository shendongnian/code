    static void Main(string[] args)
    {
        var sum = GetNumbers().TryCast<double>.Sum();
    }
    private static IEnumerable<object> GetNumbers()
    {
        yield return 4.478;
        yield return 4f;
        yield return 0xFF;
        yield return false;
        yield return new List<string> { "foo", "bar" };
    }
    // the extension function
    public static IEnumerable<T> TryCast<T>(this IEnumerable<object> values)
    {
        foreach (var v in values)
        {
            if (v is T)
                yield return (T) v;
            yield return default(T);
        }
    } 
