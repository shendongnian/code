    public static IEnumerable<DateTime> Range(DateTime start, DateTime end) {
      for (var dt = start; dt <= end; dt = dt.AddDays(1)) {
        yield return dt;
      }
    }
