    public static class Extensions
    {
        public static T MinBy<T>(this IEnumerable<T> coll, Func<T,double> criteria)
        {
            T lret = default(T);
            double last = double.MaxValue;
            foreach (var v in coll)
            {
                var newLast = criteria(v);
                if (newLast < last)
                {
                    last = newLast;
                    lret = v;
                }
            }
            return lret;
        }
    
    }
