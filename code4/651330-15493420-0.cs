    public class AdminAreaHandleErrorAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var area = filterContext.RouteData.Values["area"] as string;
            if (string.Equals(area, "Admin", StringComparison.InvariantCultureIgnoreCase))
            {
                base.OnException(filterContext);
            }
        }
    }
