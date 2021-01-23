    public static IEnumerable<T> SelectRecursively<T>(this IEnumerable<T> e,
                                                      Func<T, IEnumerable<T>> memberSelector)
    {
        foreach (T item in e)
        {
            yield return item;
            IEnumerable<T> inner = memberSelector(item);
            if (inner != null)
            {
                foreach(T innerItem in inner.SelectRecursively(memberSelector))
                {
                    yield return innerItem;
                }
            }
        }
    }
