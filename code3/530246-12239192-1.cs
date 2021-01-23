        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateGameViewModel { ConfigurableCategoryIDs = new List<int> { 1, 1, 1 } };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(CreateGameViewModel viewModel)
        {
            return View();
        }
