    interface IMyContext {
        void SaveChanges();
        IQueryable<T> Set<T>() where T: class
        IQUeryable<T> GetActiveItems<T>() where T : SomeBaseClassWithActiveProperty
    }
    public class MyContext : IMyContext {
        DataBaseContext _underylingContext = new DataBaseContext();
     
        //... save changes implementation etc   
        public IQueryable<T> Set<T>() 
               where T : class 
        {
               return _underlyingContext.Set<T>();
        }
  
        public IQueryable<T> GetActiveItems<T>() 
               where T : SomeBaseClassWithActiveProperty
        {
              return this.Set<T>().Where(item => item.IsActive == true);
        }
    }
