    public ActionResult CreateProduct()
    {
        var vm = new ProductViewModel()
            {
                SelectItems = _repository.Categories.AsEnumerable().Select(x => new SelectListItem { Text = x.Name, Value = x.ID.ToString() })
            };
    
        return View("Create", vm);
    }
