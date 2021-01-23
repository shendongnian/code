    static class Extensions {
    
      public static IEnumerable<IEnumerable<T>> ToBlocks<T>(this IEnumerable<T> source, int blockSize) {
        var count = 0;
        T[] block = null;
        foreach (var item in source) {
          if (block == null)
            block = new T[blockSize];
          block[count++] = item;
          if (count == blockSize) {
            yield return block;
            block = null;
            count = 0;
          }
        }
        if (count > 0)
          yield return block.Take(count);
      }
    
    }
