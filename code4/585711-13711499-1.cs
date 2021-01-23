    static class Extensions
    {
      public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> items, int partitionSize)
      {
        return new PartitionHelper<T>(items, partitionSize);
      }
      private sealed class PartitionHelper<T> : IEnumerable<IEnumerable<T>>
      {
        readonly IEnumerable<T> items;
        readonly int partitionSize;
        bool hasMoreItems;
        internal PartitionHelper(IEnumerable<T> i, int ps)
        {
          items = i;
          partitionSize = ps;
        }
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
          using (var enumerator = items.GetEnumerator())
          {
            hasMoreItems = enumerator.MoveNext();
            while (hasMoreItems)
              yield return GetNextBatch(enumerator).ToList();
          }
        }
        IEnumerable<T> GetNextBatch(IEnumerator<T> enumerator)
        {
          for (int i = 0; i < partitionSize; ++i)
          {
            yield return enumerator.Current;
            hasMoreItems = enumerator.MoveNext();
            if (!hasMoreItems)
              yield break;
          }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
          return GetEnumerator();      
        }
      }
    }
