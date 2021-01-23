    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Notifications = new[]
                {
                    NotificationDeliveryType.Email,
                    NotificationDeliveryType.InSystem | NotificationDeliveryType.Text
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            return View(model);
        }
    }
