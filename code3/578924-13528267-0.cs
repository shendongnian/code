    [HttpPost]
    public ActionResult Compare(myModel model)
    {
 
        var product = SelectProduct(model.reference); // selects the product from a list of cached products.
        if (product != null)
        {
           // _productDetails is a Model specifically for my View.
           // you can always update the model you got in the first place and send it back
            model.ComparedProducts.Add(product); //
        }
    return View("Index", model);
 
