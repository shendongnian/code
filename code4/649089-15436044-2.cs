    ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            //note that i have also used the dependancy injection. so i'm skiping that
            _catRepo = catRepo;
        }
        public ActionResult Index()
        {
            //ViewBag.CategoriesList = _catRepo.GetAllCategories();
               or
            return View(_catRepo.GetAllCategories());
        }
