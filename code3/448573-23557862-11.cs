    public ActionResult Test(ViewModel viewModel)
    {
        var modelStateAdapter = new ModelStateAdapter(ModelState);
        _serviceName.CreateDebitRequest(viewModel.UserId, viewModel.CardId, ... , modelStateAdapter);
 
        if(ModelState.IsValid)
            return View("Success")
        return View(viewModel);
    }
