    public static T GetMin<T, TOrder>(this IEnumerable<T> self, Func<T, TOrder> orderFunc, 
                                      out int minIndex, IComparer<TOrder> cmp = null)
    {
        if (self == null) throw new ArgumentNullException("self");            
        IEnumerator<T> selfEnumerator = self.GetEnumerator();
        if (!selfEnumerator.MoveNext()) throw new ArgumentException("List is empty.", "self");
        
        if (cmp == null) cmp = Comparer<TOrder>.Default;
        T min = selfEnumerator.Current;
        minIndex = 0;
        int intCount = 1;
        while (selfEnumerator.MoveNext ())
        {
            if (cmp.Compare(orderFunc(selfEnumerator.Current), orderFunc(min)) < 0)
            {
                min = selfEnumerator.Current;
                minIndex = intCount;
            }
            intCount++;
        }
        return min;
    }
