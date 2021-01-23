    [Post]
    public ActionResult SaveInfo(MyViewModel viewModel)
    {
        var isValid = true;
        if (ModelState.IsValid)
        {
            if (!IsValidPostCode(viewModel))
            {
                isValid = false;
                ModelState.AddModelError("BillingPostalCode", "The billing postcode appears to be invalid.");
            }
            if (isValid)
            {
                return RedirectToAction("success");
            }
        }
        return View(viewModel);
    }
    private static IDictionary<string, string> countryPostCodeRegex = new Dictionary<string, string>
        {
            { "USA", "USAPostCodeRegex" },
            { "Canada", "CanadianPostCodeRegex" },
        }
    private bool IsValidPostCode(MyViewModel viewModel)
    {
        var regexString = countryPostCodeRegex[viewModel.SelectedCountry];
        var regexMatch = Regex.Match(viewModel.BillingPostalCode, regexString, RegexOptions.IgnoreCase);
        return regexMatch.Success;
    }
