    static class LinqEx
    {
        public static IEnumerable<T> Flatten<T>(this T[,] matrix)
        {
            foreach (var item in matrix) yield return item;
        }
    }
