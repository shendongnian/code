    public interface IDataContext<T>
    {
       IEnumerable<T> GetAll();
       T GetById(int id);
       int Save(T model);
    }
    public class LinqToSqlDataContext<T> : IDataContext<T>
    {
        private DataContext context = new DataContext();
    
        public IEnumerable<T> GetAll()
        {
             // query datacontext and return enumerable
        } 
        
        public T GetById(int id)
        {
             // query datacontext and return object
        }
        
        public int Save(T model)
        {
            // save object in datacontext
        }
    }
    public class MyFirstServiceClass
    {
         private IDataContext<MyClass> context;
         public MyFirstServiceClass(IDataContext<MyClass> ctx)
         {
            this.context = ctx;
         }
         ....
    }
    public class MySecondServiceClass
    {
         private IDataContext<MySecondClass> context;
         public MyFirstServiceClass(IDataContext<MySecondClass> ctx)
         {
            this.context = ctx;
         }
         ....
    }
