        public class MyDataAccessClass: IDisposable
        {
          private readonly DbDataContext _dbContext;
          public MyDataAccessClass()
          {
              _dbContext = new DbDataContext ();
          }
          public void Dispose()
          {
            _dbContext.Dispose();
          }
          public List<CoolData> GetStuff()
          {
               var d = _dbContext.CallStuff();
               return d;
          }
        }
