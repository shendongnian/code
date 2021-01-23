    public ActionResult Search(string searchString)
        {
    
            var product = from a in _db.Product.Include(a => a.Category)
                          select a;
            if (!String.IsNullOrEmpty(searchString))
            {
              string str = Convert.ToInt32(a.displaySize).ToString();
                product = product.Where(a => a.model.ToUpper().Contains(searchString.ToUpper())
                                   || str.Contains(searchString));
            }
            return View(product.ToList());
        }
