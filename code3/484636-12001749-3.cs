    public static class HiddenHelper
    {
        public static HiddenEnumerator<T> Hide<T>(this IEnumerable<T> enu )
        {
            return HiddenEnumerator<T>.Enumerable(enu);
        }
    }
