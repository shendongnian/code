    public class UserRepository : IUserRepository
    {
         MyDbContext dbContext = new MyDbContext();
    
         public IEnumerable<User> GetAll()
         {
              return dbContext.Users;
         }
    }
