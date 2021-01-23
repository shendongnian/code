        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            // Save the file on filesystem and set the filepath in the object to be saved in the DB.
        }
