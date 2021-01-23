    public static class IComparableExtension
    {
        public static ComparerResult NiceCompareTo(this IComparable a, IComparable b)
        {
            int result = a.CompareTo(b);
            if (result > 0) return ComparerResult.ALessThanB;
            if (result < 0) return ComparerResult.AGreaterThanB;
            return ComparerResult.Equal;
        }
    }
