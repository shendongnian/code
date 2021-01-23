    class ForEachRowEnumerable : IEnumerable<Tiger>
    {
        ... a class which implements an IEnumerable<Tiger> 
        that yields a single tiger...
    }
    public static IEnumerable<Tiger> ForEachRow()
    {
      return new ForEachRowEnumerable();
    }
