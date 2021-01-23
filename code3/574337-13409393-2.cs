    static IEnumerable<T> Flatten<T>(IEnumerable collection)
    {
        foreach (var o in collection)
        {
            if (o is IEnumerable && !(o is T))
            {
                foreach (T t in Flatten<T>((IEnumerable)o))
                    yield return t;
            }
            else
                yield return (T)o;
        }
    }
