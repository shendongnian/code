        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.ActionParameters["model"] = new BaseViewModel();
            // etc
        }
