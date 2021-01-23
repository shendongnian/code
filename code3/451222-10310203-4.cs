    public class DatabaseService
    {
      private Mutex _mut=new Mutex("mutex control",false);
      public void AddToDatabase(DbObject row)
      {
        mut.WaitOne();
        SaveRow(row);
        mut.ReleaseMutex();
      }
    }
