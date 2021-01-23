    [HttpPost]
    public ActionResult Edit(Product productFromForm)
    {
        // Might need this - category might get attached as modified or added
        context.Categories.Attach(productFromForm.Category);
        // This returns a change-tracking proxy if you have that turned on.
        // If not, then changing product.Category will not get tracked...
        var product = context.Products.Find(productFromForm.ProductId);
        // This will attempt to do the model binding and map all the submitted 
        // properties to the tracked entitiy, including the category id.
        if (TryUpdateModel(product))  // Note! Vulnerable to overposting attack.
        {
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
