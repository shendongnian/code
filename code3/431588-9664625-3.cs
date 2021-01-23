    static class Extensions
    {
        public static void Reset<T>(this IEnumerable<T> toReset )
        {
            if (toReset != null)
            {
                int i = toReset.Count();
            }
        }
    }
