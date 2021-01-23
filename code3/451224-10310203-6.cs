    public class DatabaseService
    {
      private object _locker=new object();
      public void AddToDatabase(DbObject row)
      {
        lock(_locker)
            SaveRow(row);
      }
    }
