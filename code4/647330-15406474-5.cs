    public class SomeAreaBaseController : Controller
    {
        public SomeAreaBaseController()
        {
            ViewBag.HasSidebar = true;
            ViewBag.Application = ...;
            ViewBag.Device = ...;
        }
        public ActionResult Menu(Guid appID, Guid deviceID)
        {
            ...
        }
    }
