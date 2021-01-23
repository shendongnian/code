    public static IEnumerable<IEnumerable<T>> Rotate (this List<T> source)
    {
      for(int i = 0; i < source.Length; i++)
      {
        yield return source.TakeFrom(i).Concat(source.TakeUntil(i));
      }
    }
      //similar to list.Skip(i-1), but using list's indexer access to reduce iterations
    public static IEnumerable<T> TakeFrom(this List<T> source, int index)
    {
      for(int i = index; i < source.Length; i++)
      {
        yield return source[i];
      }
    }
    
      //similar to list.Take(i), but using list's indexer access to reduce iterations    
    public static IEnumerable<T> TakeUntil(this List<T> source, int index)
    {
      for(int i = 0; i < index; i++)
      {
        yield return source[i];
      }
    }
