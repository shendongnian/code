    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var foo = new List<FollowItem>()
            {
                new FollowItem {action = true, FollowsUserId = 123456777},
                new FollowItem {action = true, FollowsUserId = 123456888}
            };
            return new JsonResult {Data = foo, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
        //
        // POST: /Home/
        public ActionResult Dump(List<FollowItem> followItems)
        {
            Debug.WriteLine(followItems);
            return new HttpStatusCodeResult(200);
        }
    }
    public class FollowItem
    {
        public bool action;
        public long FollowsUserId;
    }
