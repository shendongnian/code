    public class SomeAreaBaseController : Controller
    {
        public SomeAreaBaseController()
        {
            ViewBag.CurrentArea = "SomeArea";
        }
        public ActionResult Menu(Guid appID, Guid deviceID)
        {
            ...
        }
    }
