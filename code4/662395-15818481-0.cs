    public static class ListExtensions
    {
        /// <summary>
        /// Shuffle algorithm as seen `enter code here`on page 32 in the book "Algorithms" (4th edition) by Robert Sedgewick
        /// </summary>
        public static void Shuffle<T>(this IList<T> source)
        {
            var n = source.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                var r = i + RandomProvider.Instance.Next(0, n - i);
                var temp = source[i];
                source[i] = source[r];
                source[r] = temp;
            }
        }
    }
    public static class RandomProvider
    {
        [ThreadStatic]
        public static readonly Random Instance;
        static RandomProvider()
        {
            Instance = new Random();
        }
    }
