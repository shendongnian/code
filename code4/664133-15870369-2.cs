    public static class Connection
    {
        public abstract SQLiteConnection NewConnection(String file);
    }
    
    public class NormalConnection : Connection 
    {
      public override SQLiteConnection NewConnection(String file)
      {
         return new SQLiteConnection("Data Source=" + file);
      }
    }
    
    public class WALConnection : Connection 
    {
      public override SQLiteConnection NewConnection(String file)
      {
        return new SQLiteConnection("Data Source=" + file + ";PRAGMA journal_mode=WAL;"
      }
    }
