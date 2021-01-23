    public class ViewsController : Controller
    {
        public ActionResult Render(string id)
        {
            return PartialView(id);
        }
    }
