    public class HomeController : Controller
    {
        [MyActionFilter]
        public ActionResult Index(Guid accountId, int permission, int id)
        {
            return Content(string.Format("accountId={0}, permission={1}", accountId, permission));
        }
    }
