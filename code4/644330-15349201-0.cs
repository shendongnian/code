    public class UsersController : BaseCRUDController<User>
    {      
      public UsersController(IDbContextDataProvider context) : base(context) { }
    
    ...
