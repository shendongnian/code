    public class ParticipantController : Controller
    {
        private readonly ISessionManager _sessionManager;
        public ParticipantController(ISessionManager sessionManager) 
        {
            _sessionManager = sessionManager;
        }
        public ActionResult Index()
        {
            int custId = _sessionManager.CustomerID;
            //code logic about participant lists
            return View();
        }
    } 
