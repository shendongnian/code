        public static int CombineHashCodes(params object[] objects)
        {
            // From System.Web.Util.HashCodeCombiner
            int combine(int h1, int h2) => (((h1 << 5) + h1) ^ h2);
            return objects.Select(it => it.GetHashCode()).Aggregate(5381,combine);
        }
        public static int CombineHashCodes(IEqualityComparer comparer, params object[] objects)
        {
            // From System.Web.Util.HashCodeCombiner
            int combine(int h1, int h2) => (((h1 << 5) + h1) ^ h2);
            return objects.Select(comparer.GetHashCode).Aggregate(5381, combine);
        }
