    public static class ExtraEnumerable {
      public static bool Contains<T>(IEnumerable<T> source, IEnumerable<T> needle) {
        return IndexOf(source,needle)!=-1;
      }
      
      public static int IndexOf(IEnumerable<T> source,IEnumerable<T> needle) {
        return Enumerable.Range(0,source.Count()).Where(i=> needle.SequenceEqual(source.Skip(i).Take(needle.Count()))).Select(i=>(int?)i).FirstOrDefault() ?? -1;
      }
    }
