    [HttpPost]
    public ActionResult Create(SubscriptionCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var subscription = new Subscription
            {
                Amount = viewModel.Amount,
                SubscriptionByCompanies = new List<SubscriptionByCompany>()
            };
            foreach (var selectedCompany
                in viewModel.Companies.Where(c => c.IsSelected))
            {
                var company = new Company { CompanyId = selectedCompany.CompanyId };
                _context.Companies.Attach(company);
                var subscriptionByCompany = new SubscriptionByCompany
                {
                    Company = company
                };
                subscription.SubscriptionByCompanies.Add(subscriptionByCompany);
            }
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }
