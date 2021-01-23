    public class UserController : Controller
    {
       public ActionResult ShowUser()
       {
         return View();
       }
    }
    public class AccountController : Controller
    {
       public ActionResult ShowAccount()
       {
         return View("~/Views/User/ShowUser.cshtml");
       }
    }
