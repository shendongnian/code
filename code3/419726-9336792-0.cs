    using System.Collections.Generic;
    public static class Collector
    {
        public static ICollection<T> Collect(IEnumerable<T> enumerable)
        {
            return new List<T>(enumerable);
        }
    }
