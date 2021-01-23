    protected override void OnException(ExceptionContext filterContext)
    {
        base.OnException(filterContext);
        if (filterContext.HttpContext.IsCustomErrorEnabled)
        {
            if (filterContext.Exception is SecurityException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = View("FriendlyError");
                //log the exception etc...
            }
        }
    }
