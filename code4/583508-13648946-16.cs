    public abstract class BaseController : Controller
    {
        public IDocumentSession DocumentSession { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DocumentSession = ...OpenSession(); // initialize and open session
        }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }
            using (DocumentSession)
            {
                if (filterContext.Exception != null)
                {
                    return;
                }
                if (DocumentSession != null)
                {
                    DocumentSession.SaveChanges();
                }
            }
        }
        public void ExecuteCommand(Command cmd)
        {
            cmd.DocumentSession = DocumentSession;
            cmd.Execute();
        }
        public TResult ExecuteCommand<TResult>(Command<TResult> cmd)
        {
            ExecuteCommand((Command)cmd);
            return cmd.Result;
        }
    }
