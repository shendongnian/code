    public static class NullableComparableExtensions
    {
        public static int CompareTo<T>(this T? left, T? right)
            where T : struct, IComparable<T>
        {
            return left.GetValueOrDefault().CompareTo(right.GetValueOrDefault());
        }
    }
