    public class LString
    {
      private List<string>[] _lists = new List<string>[5];
    
      public void Add(int index, string value)
      {
        if (index < 0 || index > 4)
          throw new ArgumentOutOfRangeException("index");
        _lists[index].Add(value);
      }
    }
