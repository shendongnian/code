    public class UserController : Controller
    {
         private readonly UserService userService;
    
         public UserController(UserService userService)
         {
              this.userService = userService;
         }
    
         // The rest of your action methods goes here, including GetAllUsers()
    }
