     [HttpPost]
        public ActionResult Create(Product product)
        {
            TempData["Duplicate"] = null;
            if (ModelState.IsValid)
            {
                if(DQL.DuplicateCheck(product))
                {
                    TempData["Duplicate"] = "Yes";
                }
                else
                {
                    db.Product.Add(product);
                    db.SaveChanges();
                    TempData["product_model"] = product;
                    return RedirectToAction("Product", "Success");
        
                }
        
            }
        
            return View(product);
        }
