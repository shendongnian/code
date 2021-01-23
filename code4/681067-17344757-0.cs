    public class RepControllerActionInvoker : ControllerActionInvoker
    {
        ILogger _log;
        public RepControllerActionInvoker()
            : base()
        {
            _log = DependencyResolver.Current.GetService<ILogger>();
        }
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            try
            {
                return base.InvokeAction(controllerContext, actionName);
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new HttpException(500, "Internal error");
            }
        }
    }
