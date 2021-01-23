      public class WindsorActionInvoker : ControllerActionInvoker
        {
            private readonly IKernel _kernel;
    
            public WindsorActionInvoker(IKernel kernel)
            {
                _kernel = kernel;
            }
            
            protected override ExceptionContext InvokeExceptionFilters(ControllerContext controllerContext, IList<IExceptionFilter> filters, System.Exception exception)
            {
                foreach (var actionFilter in filters.Where(actionFilter => !(actionFilter.GetType() == controllerContext.Controller.GetType())))
                {
                    _kernel.InjectProperties(actionFilter);
                }
    
                return base.InvokeExceptionFilters(controllerContext, filters, exception);
            }
