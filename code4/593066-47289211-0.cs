    public static class ShouldlyIEnumerableExtensions
    {
        public static void ShouldEquivalentTo<T>(this IEnumerable<T> list, IEnumerable<T> equivalent)
        {
            list.ShouldAllBe(l => equivalent.Contains(l));
        }
    }
