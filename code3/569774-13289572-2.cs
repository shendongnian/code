    public class AccountController : Controller
    {
      [HttpPost]
      public ActionResult Test()
      {
        return Json("hello");
      }
    }
