        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(SomeClass postedValues)
        {
            // retrieve retained values
            var retained = (List<string>) TempData["RetainedValues"] ?? new List<string>();
            retained.Add(postedValues.Something);
            // save for next post
            TempData["RetainedValues"] = retained;
            // setup viewmodel
            var model = new SomeClass
            {
                RetainedValues = retained
            };
            return View("Index", model);
        }
