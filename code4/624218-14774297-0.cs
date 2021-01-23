    public class PortalController : Controller {
        public ActionResult Index(string city) {
            NewsService newsService = new NewsService();
            WeatherService weatherService = new WeatherService();
            SportsService sportsService = new SportsService();
            PortalViewModel model = new PortalViewModel {
                News = newsService.GetNews(city),
                Weather = weatherService.GetWeather(city),
                Sports = sportsService.GetScores(city)
            };
            return View(model);
        }
    }
