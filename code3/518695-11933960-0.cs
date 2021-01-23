    public static class SortingStrategies{
      static SortingStrategies() {
        ByAgeDesc = new ByAgeDescComparer();
        ByAgeAsc = new ByAgeAscComparer();
        ByIncomeDesc = new ByIncomeDescComparer()
      }
      public static IComparer ByAgeDesc { get; private set; }
      public static IComparer ByAgeAsc { get; private set; }
      public static IComparer ByIncomeDesc { get; private set; }
    }
