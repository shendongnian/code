    public abstract class HomeController : Controller
    {
        [Inject]
        public ControllerContextProvider ControllerContextProvider { get; set; }
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            ControllerContextProvider.GetControllerContext = () => ControllerContext;
            return base.BeginExecute(requestContext, callback, state);
        }
    }
