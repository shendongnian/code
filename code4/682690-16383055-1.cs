    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
         ...
        }
    }
