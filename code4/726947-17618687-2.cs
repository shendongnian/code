            public ActionResult Edit(int id = 0) {
                InvestmentFund Fund = InvestmentFundData.GetFund(id);
                return Fund == null ? (ActionResult)HttpNotFound() : View(Fund);
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(InvestmentFund Fund)
            {
                if (ModelState.IsValid)
                {
                    InvestmentFundData.Update(Fund);
                    return RedirectToAction("List");
                }
                return View(Fund);
            }
