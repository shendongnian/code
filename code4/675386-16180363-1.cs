    public ActionResult SelectProduct()
    {
      SelectProductModel model = new SelectProductModel();
      model.ProductId = -1;
      model.Products = productRepository.GetList();
      return View();
    }
    
    public ActionResult AddToInvoice(Int32? id)
    {
      //id is the ProductId sent
    }
