    public class AController : Controller
    {
          public ActionResult AControllerAction()
          {
              if (TempData["BError"] != null)
              {
                    ModelState.AddModelError("error-key", "error-value");
              }
              ...
          }
    }
    
    public class BController : Controller
    {
          public ActionResult BControllerAction()
          {
              try{Something();}
              catch(SomethingExceprion)
              {
                  TempData["BError"] = true;
                  return RedircetToAction("AController", "AControllerAction"); //assuming correct paramater order
              }
          }
    }
