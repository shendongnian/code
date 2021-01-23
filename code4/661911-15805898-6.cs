    public class BaseController : Controller
    {
        public void SetNotification(string message, ExceptionType type)
        {
           //TO DO
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            SetNotification(filterContext.Exception.Message, yourExceptionType);
            base.OnException(filterContext);
        }
    }
