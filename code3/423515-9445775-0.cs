        public static bool IsBetween<T>(this T value, T lowerBound, T upperBound)
            where T : IComparable<T>
        {
            Contract.Requires(value != null);
            Contract.Requires(lowerBound != null);
            Contract.Requires(upperBound != null);
            Contract.Requires(upperBound.CompareTo(lowerBound) >= 0);
            // ...
        }
