    public ActionResult Add()
    {
      var vm=new ProductSale();
      //The below code is hardcoded for demo. you mat replace with DB data.
      vm.Producers= new[]
      {
        new SelectListItem { Value = "1", Text = "Dealer A" },
        new SelectListItem { Value = "2", Text = "Dealer B" },
        new SelectListItem { Value = "3", Text = "Dealer C" }
      };      
      return View(vm);
    }
