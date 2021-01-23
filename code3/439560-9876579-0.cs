    [HttpPost]
    public ActionResult Edit(Product productFromForm)
    {
        // Might need this - category might get attached as modified or added
        context.Categories.Attach(productFromForm.Category);
        // This returns a change-tracking proxy.
        var product = context.Products.Find(productFromForm.ProductId);
        // This will attempt to do the model binding and map all the submitted 
        // properties to the tracked entitiy, including the category id.
        if (TryUpdateModel(product))  // Note! Vulnerable to overposting attack.
        {
            _db.SaveChanges();
            return RedirectToAction("Index");
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
