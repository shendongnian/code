    // BaseController
    public class BaseController : Controller
    {
      protected override void OnException(ExceptionContext filterContext)
      {
        if (!filterContext.ExceptionHandled)
        {
          var action = "General";
          if (filterContext.Exception is HttpException)
          {
            var httpException = filterContext.Exception as HttpException;
            switch (httpException.GetHttpCode())
            {
              case 404:
                // page not found
                action = "Error404";
                break;
              case 500:
                // server error
                action = "Error500";
                break;
              default:
                action = "General";
                break;
            }
          }
          filterContext.Result = RedirectToAction(action, "error");
          TempData["error"] = new HandleErrorInfo(filterContext.Exception, 
                              RouteData.Values["controller"].ToString(), 
                              RouteData.Values["action"].ToString());
          filterContext.ExceptionHandled = true;
        }
      }
    }
    // Error Controller
    public class ErrorController : Controller
    {
      public ActionResult Error404()
      {
        return View(TempData["error"] as HandleErrorInfo);      
      }
      // other methods
    }
    // Sample controller derives from BaseController.
    public class HomeController : BaseController
    {
      public ActionResult Index()
      {
        return View();
      }
      public ActionResult NotFound()
      {
        throw new HttpException(404, "Not Found");
      }
    }
 
    // Error404.cshtml
    @model System.Web.Mvc.HandleErrorInfo
    @{
      ViewBag.Title = "404 Not Found";
    }
    <h2>@ViewBag.Title</h2>
    <p>
      Last Exception: @Model.Exception
    </p>
