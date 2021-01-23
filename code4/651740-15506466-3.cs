    [Authorize]
    public class MyAdminReportController : Controller
    {
    
       //[Authorize]
       public ActionResult PrivatePage()
       {
          return View();
       }
    }
