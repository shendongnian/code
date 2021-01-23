    [HttpPost]
    public ActionResult Edit(SubscriptionEditViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var subscription = _context.Subscriptions.Include(s => s.Companies)
                .SingleOrDefault(s => s.SubscriptionId == viewModel.Id);
            if (subscription != null)
            {
                // Update scalar properties like "Amount"
                subscription.Amount = viewModel.Amount;
                // or more generic for multiple scalar properties
                // _context.Entry(subscription).CurrentValues.SetValues(viewModel);
                // But this will work only if you use the same key property name
                // in ViewModel and entity
                foreach (var company in viewModel.Companies)
                {
                    if (company.IsSelected)
                    {
                        if (!subscription.Companies.Any(
                            c => c.CompanyId == company.CompanyId))
                        {
                            // if company is selected but not yet
                            // related in DB, add relationship
                            var addedCompany = new Company
                                { CompanyId = company.CompanyId };
                            _context.Companies.Attach(addedCompany);
                            subscription.Companies.Add(addedCompany);
                        }
                    }
                    else
                    {
                        var removedCompany = subscription.Companies
                           .SingleOrDefault(c => c.CompanyId == company.CompanyId);
                        if (removedCompany != null)
                            // if company is not selected but currently
                            // related in DB, remove relationship
                            subscription.Companies.Remove(removedCompany);
                    }
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }
