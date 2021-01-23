    public class MyController : Controller
    {
        public ActionResult MyAction(...)
        {
            using (AssetManagerContext db = new AssetManagerContext("ConnectionString"))
            {
                // Do stuff
            }
        }
    }
