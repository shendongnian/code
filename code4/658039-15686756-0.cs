    public class RedirectFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (MyService.IsCat==false)
                return RedirectToAnotherControllerAction();
        }
    }
