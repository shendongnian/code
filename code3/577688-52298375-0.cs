    /// <summary>
    /// Generates a new list with only distinct items preserving original ordering.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IList<T> ToUniqueList<T>(this IList<T> list, IEqualityComparer<T> comparer = null)
    {
    	bool Contains(T x) => comparer == null ? list.Contains(x) : list.Contains(x, comparer);
    
    	return list.Where(entity => !Contains(entity)).ToList();
    }
