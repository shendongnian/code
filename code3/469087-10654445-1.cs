    public static class RandomExtensions
    {
        private static readonly Random rnd = new Random();
        private static readonly object sync = new object();
        public static T RandomElement<T>(this IEnumerable<T> enumerable) {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            var count = enumerable.Count();
            
            var ndx = 0;
            lock (sync) 
                ndx = rnd.Next(count); // returns non-negative number less than max
            return enumerable.ElementAt(ndx); 
        }
    }
