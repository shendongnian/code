    public static bool IsExactlyOneTrue(IEnumerable<Func<bool>> conditions)
    {
      int passingConditions = conditions
        .Where(x => x())
        // .Take(2) //optimization
        .Count();
      return passingConditions == 1;
    }
