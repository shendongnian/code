    public interface IUserService
    {
        public void Delete(User entity);
    }
    //
    // This class would be used Linq to Entities 
    public class LinqUserService : IUserService 
    {
        public void Delete (User entity)
        {
        }  
    }
    // 
    // This class would be used Sql command
    public class SqlUserService : IUserService
    {
        public void Delete (User entity)
        {
        } 
    }
