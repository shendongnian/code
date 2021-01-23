    public ActionResult Edit(int id)
    {
        // Load the subscription with the requested id from the DB
        // together with its current related companies (only their Ids)
        var data = _context.Subscriptions
            .Where(s => s.SubscriptionId == id)
            .Select(s => new
            {
                ViewModel = new SubscriptionEditViewModel
                {
                    Id = s.SubscriptionId
                    Amount = s.Amount
                },
                CompanyIds = s.Companies.Select(c => c.CompanyId)
            })
            .SingleOrDefault();
        if (data == null)
            return HttpNotFound();
        // Load all companies from the DB
        data.ViewModel.Companies = _context.Companies
            .Select(c => new CompanySelectViewModel
            {
                CompanyId = c.CompanyId,
                Name = c.Name
            })
            .ToList();
       
        // Set IsSelected flag: true (= checkbox checked) if the company
        // is already related with the subscription; false, if not
        data.ViewModel.Companies.ForEach(
            c => { c.IsSelected = data.CompanyIds.Contains(c.CompanyId); });
        return View(data.ViewModel);
    }
