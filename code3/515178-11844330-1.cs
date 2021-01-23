    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string country)
        {
            var countryId = GetCountries()
                            .Where(c => c.Country.ToLower() == country.ToLower())
                            .Select(c => c.Id)
                            .SingleOrDefault();
            if (countryId != 0)
                return RedirectToAction("Thanks");
            else
                ModelState.AddModelError("CountryNotSelected", "You have selected an invalid country.");
            return View();
        }
        private List<CountryModel> GetCountries()
        {
            return new List<CountryModel>
            {
                new CountryModel { Id = 1, Country = "Russia" },
                new CountryModel { Id = 2, Country = "USA" },
                new CountryModel { Id = 3, Country = "Germany" }
            };
        }
    }
