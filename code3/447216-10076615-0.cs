    var customerSummary = CustomerManager.CustomerRepository.GetQuery();
    
    if ("desc".Equals(sortDir, StringComparison.CurrentCultureIgnoreCase))
       customerSummary = customerSummary.OrderByDescending(sort);
    else
       customerSummary = customerSummary.OrderBy(sort);
    
    var pageNumber = page.GetValueOrDefault();
    if (pageNumber < 1)
       pageNumber = 1;
    
    customerSummary = customerSummary
       .Select(c => new CustomerSummaryViewModel()
          {
             Id = c.Id,
             Name = c.Name,
             IsActive = c.IsActive,
             OrderCount = c.Orders.Count
          })
       .Skip((pageNumber - 1) * 10) 
       .Take(10)
       .ToList();
