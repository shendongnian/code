     public static class LinqExtentions
    {
        /// <summary>
        /// Note: For the compare parameters; First the low, than the High
        /// </summary>
        /// <returns>Bool</returns>
        public static bool Between<T1, T2, T3>(this T1 actual, T2 lowest, T3 highest)
            where T1 : IComparable
            where T2 : IConvertible
            where T3 : IConvertible
        {
            return actual.CompareTo(lowest.ToType(typeof(T1), null)) >= 0 &&
                   actual.CompareTo(highest.ToType(typeof(T1), null)) <= 0;
        }
    }
    public class TwoUintsKeyInfo
    {
        public uint IdOne { get; set; }
        public uint IdTwo { get; set; }
        public class EqualityComparerTwoUintsKeyInfo : IEqualityComparer<TwoUintsKeyInfo>
        {
            public bool Equals(TwoUintsKeyInfo x, TwoUintsKeyInfo y)
            {
                return x.IdOne == y.IdOne &&
                        x.IdTwo == y.IdTwo;
            }
            public int GetHashCode(TwoUintsKeyInfo x)
            {
                return (Math.Pow(x.IdOne, Math.E) + Math.Pow(x.IdTwo, Math.PI)).GetHashCode();
            }
        }
    }
