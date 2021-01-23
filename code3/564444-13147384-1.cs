    Random random = new Random();
    foreach (var element in Generate(() => random.Next(99), 10))
    {
        Console.WriteLine(element);
    }
---
    public static IEnumerable<T> Generate<T>(Func<T> factory, int elements)
    {
        for (int generated = 0; generated < elements; generated++)
        {
            yield return factory();
        }
    }
