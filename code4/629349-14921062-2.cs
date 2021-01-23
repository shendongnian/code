    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        var unitOfWork = (IUnitOfWork) actionExecutedContext.Request.Properties[UnitOfWorkRequestKey];
        try
        {
            if (actionExecutedContext.Exception == null)
            {
                unitOfWork.Complete();
            }
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }
