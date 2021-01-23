    [HttpPost]
    public ActionResult Create(SubscriptionCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var subscription = new Subscription
            {
                Amount = viewModel.Amount,
                Companies = new List<Company>()
            };
            foreach (var selectedCompany
                in viewModel.Companies.Where(c => c.IsSelected))
            {
                var company = new Company { CompanyId = selectedCompany.CompanyId };
                _context.Companies.Attach(company);
                subscription.Companies.Add(company);
            }
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }
