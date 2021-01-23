      public class ErrorController : Controller
      {
          public ActionResult Http404()
          {
              return View("~/BaseViews/Error/Http404.cshtml");
          }
      }
