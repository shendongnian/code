    public class SomeAreaBaseController : Controller
    {
        public SomeAreaBaseController()
        {
            ViewBag.HasSidebar = true;
        }
        public ActionResult Menu(Guid appID, Guid deviceID)
        {
            ...
        }
    }
