    [HttpPost]
    public ActionResult Index(CountryViewModel viewModel)
    {
        var countryId = GetCountries()
                        .Where(c => c.Country.ToLower() == viewModel.Country.ToLower())
                        .Select(c => c.Id)
                        .SingleOrDefault();
        if (countryId != 0)
            return RedirectToAction("Thanks");
        else
            ModelState.AddModelError("CountryNotSelected", "You have selected an invalid country.");
        return View(viewModel);
    }
