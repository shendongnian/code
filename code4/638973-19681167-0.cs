    public class LogExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(typeof (LogExceptionFilter));
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            log.Error("Unhandeled Exception", actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
