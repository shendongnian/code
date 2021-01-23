    public class UserDomainService : IUserDomainService
    {
       private readonly IRepositoryFactory RepositoryFactory;
    
       public UserDomainService(IRepositoryFactory factory)
       {
          RepositoryFactory = factory;
       }
    
       public User CreateNewUser(User user)
       {
          using (IRepository repository = RepositoryFactory.Create())
          {
             var user = repository.FindBy(user.UserName);
             if(user != null)
                throw new Exception("User name already exists!");
    
             repository.Add(user);
             repository.Commit();
          }
       }
    }
