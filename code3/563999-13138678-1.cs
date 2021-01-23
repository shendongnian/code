    public class MPPController {
      public ActionResult Index(){
        ViewData["UserName"] = TempData["UserName"];
      }
    }
