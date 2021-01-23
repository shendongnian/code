    [HttpPost]
    public ActionResult Edit (ProductViewModel newModel)
    {
      var oldProduct=repositary.GetProduct(newModel.ProductID);
      oldProduct.ProductPrice=newModel.ProductPrice;
    
      //Now save the oldProdcut
    
    }
