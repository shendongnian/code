    public static IEnumerable<Tiger> Parse()
    {
      object obj = ForEachRow();
      yield return (Tiger) obj;
    }
    public static IEnumerable<Tiger> ForEachRow()
    {
      yield return new Tiger();
    }
