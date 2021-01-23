    public class HomeController
    {
        public ActionResult Index()
        {
            var notificationProvider = new NotificationProvider(this);
            notificationProvider.LoadNotifications();
            return View();
        }
    }
