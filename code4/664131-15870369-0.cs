    public static class Connection
    {
        public abstract SQLiteConnection NewConnection(String file);
    }
    
    public class NormalConnection : Connection 
    {
      public override SQLiteConnection NewConnection(String file)
      {
         return new SQLLiteConneciton("Data Source=" + file);
      }
    }
    
    public class WALConnection : Connection 
    {
      public override SQLiteConnection NewConnection(String file)
      {
        return new SQLLiteConnection("Data Source=" + file + ";PRAGMA journal_mode=WAL;"
      }
    }
