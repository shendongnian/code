        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            var model = new CardsFiltersViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CardsFiltersViewModel model)
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View(model);
        }
        public ActionResult About()
        {
            return View();
        }
    }
