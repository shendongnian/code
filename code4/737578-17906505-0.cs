    [DebugLogAttribute]
    public class HOmeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
    
    internal class DebugLogAttribute : ActionFilterAttribute
    {
        public IDataAccessProvider DataAccess { get; set; }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debugger.Break();
        }
    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debugger.Break();
        }
    }
    
    internal interface IDataAccessProvider {}
    
    internal class DataAccessProvider:IDataAccessProvider {}
