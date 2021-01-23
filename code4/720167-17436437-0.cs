    public class MySurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        public ActionResult Index() 
        {
            return Content("hello world");
        }
    }
