    public class ProductsController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext){
            TempData["previousUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
            base.OnActionExecuting(filterContext);
        }
    }
