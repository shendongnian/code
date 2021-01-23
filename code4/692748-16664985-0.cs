    var pm = new ManagerClass();
    var po = pm.GetDataFromDb();
    ViewBag.Policies = new SelectList(po, "PolicyID", "PolicyName");
    viewModel.PolicyID = 7;
    return View(viewModel);
