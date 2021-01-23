    public class UserController : Controller
    {
         private readonly IUserService userService;
    
         public UserController(IUserService userService)
         {
              this.userService = userService;
         }
    
         // The rest of your action methods goes here, including GetAllUsers()
    }
