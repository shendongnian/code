        protected virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.ViewName = viewResult.ViewName.Replace("...", "...");
            }
            base.OnActionExecuted(filterContext);
        }
