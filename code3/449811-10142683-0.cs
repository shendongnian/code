    public ActionResult Search(string searchString)
        {
    
            var product = from a in _db.Product.Include(a => a.Category)
                          select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.ToList().Where(a => a.model.ToUpper().Contains(searchString.ToUpper())
                                   || Convert.ToInt32(a.displaySize).ToString().Contains(searchString));
            }
            return View(product.ToList());
        }
