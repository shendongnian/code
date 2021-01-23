    public class HomeController : BaseController
    {
     public ActionResult Assistance()
        {
            var user = GetCurrentUser();
            var mdl = new RequestModel(user);
            return View(mdl);
        }
    }
