    public class DataManager<T> where T:ObjectContext
    {
      protected T _context;
    
      public DataManager(T context)
      {
         _context = context;
      }
    }
