    [HttpPost]
    public ActionResult Foo(BarViewModel viewModel)
    {
        viewModel.Validate(ValidationDictionary);
    
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
    
        // Calls to servicelayer
    }
