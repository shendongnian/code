    public class PortalController : Controller {
        public async Task<ActionResult> Index(string city) {
            NewsService newsService = new NewsService();
            WeatherService weatherService = new WeatherService();
            SportsService sportsService = new SportsService();
            var newsTask = newsService.GetNewsAsync(city);
            var weatherTask = weatherService.GetWeatherAsync(city);
            var sportsTask = sportsService.GetScoresAsync(city);
            await Task.WhenAll(newsTask, weatherTask, sportsTask);
            PortalViewModel model = new PortalViewModel {
                News = newsTask.Result,
                Weather = weatherTask.Result,
                Sports = sportsTask.Result
            };
            return View(model);
        }
    }
