    public ActionResult Create()
    {
        var viewModel = new SubscriptionCreateViewModel
        {
            Companies = _context.Companies
                .Select(c => new CompanySelectViewModel
                {
                    CompanyId = c.CompanyId,
                    Name = c.Name,
                    IsSelected = false
                })
                .ToList()
        };
        return View(viewModel);
    }
