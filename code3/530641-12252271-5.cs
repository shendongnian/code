    public ActionResult Add()
    {
      var vm=new ProductSale();
      //The below code is hardcoded for demo. you mat replace with DB data.
      vm.Products= new[]
      {
        new SelectListItem { Value = "1", Text = "Product A" },
        new SelectListItem { Value = "2", Text = "Dealer B" },
        new SelectListItem { Value = "3", Text = "Product C" }
      };      
      return View(vm);
    }
