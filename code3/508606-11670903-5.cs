    public static IEnumerable<T> ReduceN<T>(this IEnumerable<T> values, Func<T, T, T> map, int N)
    {
        int counter = 0;
        T previous = default(T);
        foreach (T item in values)
        {
            counter++;
            if (counter == 1)
            {
                previous = item;
            }
            else if (counter == N)
            {
                yield return map(previous, item);
                counter = 0;
            }
            else
            {
                previous = map(previous, item);
            }
        }
    
        if (counter != 0)
        {
            yield return previous;
        }
    }
