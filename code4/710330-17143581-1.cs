    [HttpPost]
    public ActionResult Payout(PayoutViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var user = PublicUtility.GetAccount(User.Identity.Name);
        var validationMessages = user.ValidatePayout(model.WithdrawAmount)
        if(validationMessages.Any())
        {
            ViewBag.Message = validationMessages.ToSummary();
            return View(model);
        }
        ViewBag.Message = "Successfully withdrew " + model.WithdrawAmount;
        model.Balance = user.Balance;
        model.WithdrawAmount = 0;
        return View(model);
    }
