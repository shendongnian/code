    public class Cache
    {
      private List<Item> cachedItems = new List<Item>();
    
      public void Add(Item item)
      {
       lock(cachedItems)
       {
        cachedItems.Add(item);
       }
      }
    }
