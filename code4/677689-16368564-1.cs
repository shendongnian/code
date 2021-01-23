        public ActionResult Index()
        {
            MyViewModel vm = new MyViewModel();
            //doing something here....
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel vm)
        {
            //save your data, here your viewmodel will be correctly filled
            return View(vm);
        }
