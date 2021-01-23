    public ActionResult MNPurchase() {
    	CalculationViewModel calculationViewModel = (CalculationViewModel)TempData["calculationViewModel"];
    
    	if (calculationViewModel != null) {
    		decimal OP = landTitleUnitOfWork.Sales.Find()
    										.Where(x => x.Min >= calculationViewModel.SalesPrice)
    										.FirstOrDefault()
    										.OP;
    
    		decimal MP = landTitleUnitOfWork.Sales.Find()
    										.Where(x => x.Min >= calculationViewModel.MortgageAmount)
    										.FirstOrDefault()
    										.MP;
    
    		calculationViewModel.LoanAmount = (OP + 100) - MP;
    		calculationViewModel.LendersTitleInsurance = (calculationViewModel.LoanAmount + 850);
    
    
    		return View(calculationViewModel);
    	} else {
    		// Do something else...
    	}
    }
