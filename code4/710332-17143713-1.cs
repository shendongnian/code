        [HttpPost]
        public ActionResult Payout(PayoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = accountRepository.FindAccountFor(User.Identity.Name);
                if (account.CanWithdrawMoney(model.WithdrawAmount))
                {
                    account.MakeWithdrawal(model.WithdrawAmount);
                    ViewBag.Message = "Successfully withdrew " + model.WithdrawAmount;
                    model.Balance = account.Balance;
                    model.WithdrawAmount = 0;
                    return View(model);
                }
     
                ViewBag.Message = "Not enough funds on your account";
                return View(model); 
            }
            else
            {
                return View(model);
            }
        }
