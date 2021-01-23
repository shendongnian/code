    [HttpPost]
    public ActionResult Payout(PayoutModel model)
    {
        if (ModelState.IsValid)
        {
            var result = service.Payout(User.Identity.Name, model);
            // This part should only be in the MVC project since it deals with 
            // how things should be presented to the user
            switch (result)
            {
                case PayoutResult.UserNotFound:
                    ViewBag.Message = "User not found";
                    break;
                case PayoutResult.Success:
                    ViewBag.Message = string.Format("Successfully withdraw {0:c}", model.Balance);
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
