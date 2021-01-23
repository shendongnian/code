    public interface IDataContext
    {
       IEnumerable<MyModel> GetAll();
       MyModel GetById(int id);
       int Save(MuModel model);
    }
    public class LinqToSqlDataContext : IDataContext
    {
        private DataContext context = new DataContext();
    
        public IEnumerable<MyModel> GetAll()
        {
             // query datacontext and return enumerable
        } 
        
        public MyModel GetById(int id)
        {
             // query datacontext and return object
        }
        
        public int Save(MuModel model)
        {
            // save object in datacontext
        }
    }
