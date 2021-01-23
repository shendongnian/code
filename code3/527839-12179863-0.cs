    [Authorize(Roles = "Viewers, Editors")]
    public class BaseController : Controller
    {
    
        [Authorize(Roles = "Editors")]
        public ActionResult EditReport(PaymentsUnallocatedAndQueriedModel model)
        {
            // Some editor only functionality
        }
    
        public ActionResult Report(PaymentsUnallocatedAndQueriedModel model)
        {
            // Some functionality for both. No attribute needed
        }
    }
