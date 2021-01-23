    public class UserController : Controller
    {
         private readonly IUserRepository userRepository;
    
         public UserController(IUserRepository userRepository)
         {
              this.userRepository = userRepository;
         }
    
         public ActionResult Index()
         {
              UserViewModel viewModel = new UserViewModel
              {
                   Users = userRepository.GetAll()
              };
         }
    }
