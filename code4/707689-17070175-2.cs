    [HttpPost]
    public ActionResult Method(SomeMethodViewModel model)
    {
        if(_someMethodViewModelValidator.HasError(model, ModelState, SetModelState))
        {
            var viewModel = GetViewModel();
            viewModel.SomeMethod = model;
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
