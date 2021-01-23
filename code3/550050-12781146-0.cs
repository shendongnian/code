    public static class ExtensionMethods
    {
      public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list)
      {
        var distinctList = new List<T>();
        foreach (var item in list)
        {
          if (!distinctList.Contains(item)) distinctList.Add(item);
        }
        return distinctList;
      }
    }
