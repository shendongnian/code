    public static bool AnyOf<TElement>(this TElement item, IEnumerable<TElement> items)
    {
        var parallelItems = items as ParallelQuery<TElement>
        if(parallelItems != null)
        {
             return parallelItems.Any(a => EqualityComparer<TElement>.Default.Equals(a, item))
        }
        //other runtime checks
        ....
        //else return default IEnumerable implementation
        return items.Any(a => EqualityComparer<TElement>.Default.Equals(a, item));
    }
