    [HttpPost]
    public ActionResult Payout(PayoutModel model)
    {
        if (ModelState.IsValid)
        {
            var result = service.Payout(User.Identity.Name, model);
            // This part should only be in MVC
            switch (result)
            {
                case PayoutResult.UserNotFound:
                    ViewBag.Message = "User not found";
                    break;
                case PayoutResult.Success:
                    ViewBag.Message = "Successfully withdrew " + model.Balance;
                    break;
                case PayoutResult.FundsUnavailable:
                    ViewBag.Message = "Insufficient funds";
                    break;
                default:
                    break;
            }               
        }
        return View(model);
    }
