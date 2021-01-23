      public class Robot : IDisposable
      {
        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();
    
        public int ID { get; private set; }
    
        public Robot()
        {
    
          lock (Lock)
          {
            int nextIndex = GetAvailableIndex();
            if (nextIndex == -1)
            {
              nextIndex = UsedCounter.Count;
              UsedCounter.Add(true);
            }
    
            ID = nextIndex;
          }
        }
    
        public void Dispose()
        {
          lock (Lock)
          {
            UsedCounter[ID] = false;
          }
        }
    
    
        private int GetAvailableIndex()
        {
          int UsedCounterCount = UsedCounter.Count;
          for (int i = 0; i < UsedCounterCount; i++)
          {
            if (UsedCounter[i] == false)
            {
              return i;
            }
          }
    
          // Nothing available.
          return -1;
        }
