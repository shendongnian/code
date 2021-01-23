    [Authorize]
    public class UserController : Controller {
    
       [AllowAnonymous]
       public ActionResult LogIn () {
          // This action can be accessed by unauthorized users
       }
    
       public ActionResult UserDetails () {
          // This action can NOT be accessed by unauthorized users
       }
    }
