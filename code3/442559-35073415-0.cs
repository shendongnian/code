    static class Extensions
    {
        public static IEnumerable<T> RotateLeft<T>(this IEnumerable<T> e, int n) =>
            n >= 0 ? e.Skip(n).Concat(e.Take(n)) : e.RotateRight(-n);
    
        public static IEnumerable<T> RotateRight<T>(this IEnumerable<T> e, int n) =>
            e.Reverse().RotateLeft(n).Reverse();
    }
