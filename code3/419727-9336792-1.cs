    public static class Collector
    {
        public static System.Collections.Generic.ICollection<T> Collect(System.Collections.Generic.IEnumerable<T> enumerable)
        {
            return new System.Collections.Generic.List<T>(enumerable);
        }
    }
