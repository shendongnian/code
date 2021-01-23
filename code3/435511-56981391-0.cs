    public class BaseController : Controller
    {
            public BaseController()
            {
                // get the previous url and store it with view model
                ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            }
    }
