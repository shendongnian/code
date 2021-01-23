    public ActionResult Order()
    {
     
     OrderViewModel orderVM=new OrderViewModel();
     orderVM.Products=ProductService.GetAvailableProducts();
     return View(orderVM);
    }
