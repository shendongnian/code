    public class SomeAreaBaseController : Controller
    {
        public SomeAreaBaseController()
        {
            ViewBag.CurrentArea = "SomeArea";
        }
        public ActionResult RenderSideBar()
        {
            ...
        }
    }
