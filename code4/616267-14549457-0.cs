    public class HomeController: Controller
    {
        private readonly ISettingsManager settingsManager;
        public HomeController(ISettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
        }
    
        public ActionResult Index()
        {
            // you could use the this.settingsManager here
        }
    }
