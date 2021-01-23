    [HttpPost]
    public ActionResult ApplicationPoolsUpdate(ServiceViewModel viewModel)
    {
        XDocument updatedResultsDocument = myService.UpdateApplicationPools();
        TempData["doc"] = updatedResultsDocument;
        return RedirectToAction("UpdateConfirmation");
    }
