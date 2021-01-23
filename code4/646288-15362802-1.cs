    private static Thread thread;
    private static List<object> items = new List<object>();
    private Object theLock = new Object();
    
    static Program()
    {
      thread = new Thread(() =>
        {
          lock(theLock)
          {
            foreach (var item in items)
            {
              item.Name = "ABC";
            }
          }
          Thread.Sleep(3600);
        });
      thread.Start();
    }
    
    private static void Main(string[] args)
    {
      lock(theLock)
      {
        var item = items.Where(i => i.Name == "ABC").FirstOrDefault();
        if(item != null)
        {
          items.Remove(item);
        }
      }
    } 
