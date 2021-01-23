    private static bool DictionaryEquals<TKey, TValue>(Dictionary<TKey, TValue> left, Dictionary<TKey, TValue> right)
    {
        var comp = EqualityComparer<TValue>.Default;
        if (left.Count != right.Count)
        {
            return false;
        }
    
        if (left.Keys.Intersect(right.Keys).Count() != left.Count)
            return false;
            //there is a key in the left dictionary that's not in the right dictionary
            //if there are any keys in the right dictionary not in the left then either 
            //there is one in the left not in the right as well, or the counts won't have 
            //been equal, so we know the two key sets are equal.
    
        var defaultValueComparer = EqualityComparer<TValue>.Default;
    
        Func<TValue, TValue, bool> valueComparer;
    
        if (typeof(TValue) is IEnumerable)
            valueComparer = (first, second) => ((IList)first).SequenceEqual((IList)second);
        else
            valueComparer = (first, second) => defaultValueComparer.Equals(first, second);
    
        foreach (var key in left.Keys)
        {
            if (!valueComparer(left[key], right[key]))
                return false;
        }
    
        return true;
    }
    
    public static bool SequenceEqual(this IList first, IList second)
    {
        if (first.Count != second.Count)
            return false;
    
        IEnumerator iterator1 = first.GetEnumerator(),
                    iterator2 = second.GetEnumerator();
    
        while (true)
        {
            bool next1 = iterator1.MoveNext();
            bool next2 = iterator2.MoveNext();
            // Sequences aren't of same length. We don't 
            // care which way round. 
            if (next1 != next2)
            {
                return false;
            }
            // Both sequences have finished - done 
            if (!next1)
            {
                return true;
            }
            if (!object.Equals(iterator1.Current, iterator2.Current))
            {
                return false;
            }
        }
    }
