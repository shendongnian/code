    public static bool ContainsSequence<T>(this IEnumerable<T> outer, 
                                           IEnumerable<T> inner)
    {
        var innerCount = inner.Count();
        for(int i = 0; i < outer.Count() - innerCount; i++)
        {
            if(outer.Skip(i).Take(innerCount).SequenceEqual(inner))
                return true;
        }
    
        return false;
     }
