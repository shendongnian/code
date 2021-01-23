        public ViewResult CreateProduct()
        {
            ViewBag.CategoryList = _repository.Categories.Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() });
            return View("EditProduct", new Product());
        }
