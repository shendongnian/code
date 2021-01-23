    public static IEnumerable<T1> Filter<T1, T2>(
        this IEnumerable<T1> one, 
        IEnumerable<T2> two, string property)
            {
               var result = one.Where(o => two.Any(t =>
                   o.GetType().GetProperty(property).
                   GetValue(o, null).Equals(t.GetType().
                   GetProperty(property).GetValue(t, null))));
               return result;
            }
