    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> items, Predicate<T> p)
    {
        while (true)
        {
            items = items.SkipWhile(i => !p(i));
            var trueItems = items.TakeWhile (i => p(i)).ToList();
            if (trueItems.Count > 0)
            {
                yield return trueItems;
                items = items.Skip(trueItems.Count);
            }
            else
            {
                break;
            }
        }	
    }
