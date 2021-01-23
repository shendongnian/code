    public ActionResult Products()
    {
      List<Products> products = SomeMethodToGetProducts();
      
      return View(products);
    }
   
