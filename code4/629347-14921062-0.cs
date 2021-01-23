    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var unitOfWork = (IUnitOfWork) filterContext.HttpContext.Items[UnitOfWorkRequestKey];
        try
        {
            if (filterContext.Exception == null)
            {
                unitOfWork.Complete();
            }
        }
        finally
        {
            unitOfWork.Dispose();
            filterContext.Controller.TempData[UnitOfWorkRequestKey] = null;
        }
    }
