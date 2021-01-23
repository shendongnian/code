    public ActionResult Index()
        {
            var vm = new MovieIndexViewModel();
            vm.TopTenByDate = ....;
            vm.TomTenByRating = ...;
    
            return View(vm );
    
        }
