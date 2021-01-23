    public class ThreadSafeList
    {
      private readonly object locker = new object();
      private List<int> myList = new List<int>();
    
      public void Add(int item)
      {
        lock(locker)
          myList.Add(item);
      }
      public void Clear()
      {
        lock(locker)
          myList.Clear();
      }
      public int Count
      {
        lock(locker)
          return myList.Count;
      }
      public int Item(int index)
      {
        lock(locker)
          return myList[index];
      }
    }
