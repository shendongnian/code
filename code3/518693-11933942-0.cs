    public static class SortingStrategy
    {
        public static readonly IComparer<Person> ByAgeDescending = ...;
        public static readonly IComparer<Person> ByAgeAscending = ...;
        public static readonly IComparer<Person> ByIncomeDescending = ...;
        public static readonly IComparer<Person> ByIncomeAscending = ...;
    }
