    public ActionResult DetailForProductID(int productID)
    {
        IEnumerable<Product> data =   GetProductById(productID);
        TempData["ProductData"]= data;
        return RedirectToAction("Detail",data);        
    }
    
    public ActionResult Detail(IEnumerable<Product> products)
    {
       ....
        if(TempData["ProductData"]!=null){
           IEnumerable<Product> data =  (IEnumerable<Product>)TempData["ProductData"];
           return View(data);
        }else {
           return View(products);
        }
    }
