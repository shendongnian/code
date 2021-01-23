    [Authorize(Roles = "AdminRole, CreditAdvisorRole")]
    public ActionResult Edit()
    {
        var viewModel = _shopService.ShopIndex();
        return View(viewModel);
    }
