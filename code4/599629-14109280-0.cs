    public bool AllEqual<T>(IEnumerable<T> items)
    {
        // This could be a parameter if you want
        var comparer = EqualityComparer<T>.Default;
        using (var iterator = items.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return true; // Empty sequence
            }
            var first = iterator.Current;
            while (iterator.MoveNext())
            {
                if (!comparer.Equals(first, iterator.Current))
                {
                    return false;
                }
            }
        }
        return true;
    }
