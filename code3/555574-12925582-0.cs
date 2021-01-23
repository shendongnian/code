    public class LoginController:Controller
    {
      public ActionResult Index()
      {
        return View();
        //this method will return `~/Views/Login/Index.csthml/aspx` file
      }
      public ActionResult RecoverPassword()
      {
        return View();
        //this method will return `~/Views/Login/RecoverPassword.csthml/aspx` file
      }
    }
