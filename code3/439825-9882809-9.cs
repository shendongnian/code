    public ActionResult Order()
    {     
       var orderVM=new OrderViewModel();
       //Items hard coded for demo. You may replace with values from your db
       orderVM.Products= new List<ProductViewModel>
        {
            new ProductViewModel{ ID=1, Name="IPhone" },
            new ProductViewModel{ ID=2, Name="MacBook Pro" },
            new ProductViewModel{ ID=3, Name="iPod" }           
        };
       return View(orderVM);
    }
