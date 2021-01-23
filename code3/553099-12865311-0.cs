    public interface IStructure<T>
    {
      void InsertRun(T item);
      ICollection<T> RetrieveSortedListRun();
      T RetrieveItemRun(T item);
    }
    class DictionaryRun<T> : IStructure<T>
    {
      IDictionary<int, T> dictionary;
      public DictionaryRun()
      {
        dictionary = new Dictionary<int, T>();
      }
      public void InsertRun(T item)
      {
        dictionary.Add(dictionary.Count + 1, item);
      }
      public ICollection<T> RetrieveSortedListRun()
      {
        return dictionary.Values;
      }
      public T RetrieveItemRun(T item)
      {
        return item;
      }
    }
