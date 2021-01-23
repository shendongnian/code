    public abstract class SortingStrategy : IComparer<Person>
    {
        public static readonly SortingStrategy ByAgeDescending = ...;
        public static readonly SortingStrategy ByAgeAscending = ...;
        public static readonly SortingStrategy ByIncomeDescending = ...;
        public static readonly SortingStrategy ByIncomeAscending = ...;
        private SortingStrategy() {}
        private class ByAgeStrategy : SortingStrategy { ... }
        private class ByIncomeStrategy : SortingStrategy { ... }
    }
