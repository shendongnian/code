        public static T MinValue<T>(this IEnumerable<T> self, Func<T, double> sel)
        {
            double run = double.MaxValue;
            T res = default(T);
            foreach (var element in self)
            {
                var val = sel(element);
                if (val < run)
                {
                    res = element;
                    run = val;
                }
            }
            return res;
        }
