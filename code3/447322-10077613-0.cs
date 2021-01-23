        [HttpPost]
        public ActionResult Index(Home home)
        {
            ViewBag.Message = "Welcome to ASP.NET MVC! (after a submit)";
            ModelState.Remove("Date2");
            home.Date2 = home.Date2.AddDays(1);
            return View("Index", home);
        }
