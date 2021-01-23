     public class UnitOfWorkAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var context = IoC.CurrentNestedContainer.GetInstance<DatabaseContext>();
                context.BeginTransaction();
            }
    
            public override void OnActionExecuted(HttpActionExecutedContext actionContext)
            {
                var context = IoC.CurrentNestedContainer.GetInstance<DatabaseContext>();
                context.CloseTransaction(actionContext.Exception);
            }
        }
