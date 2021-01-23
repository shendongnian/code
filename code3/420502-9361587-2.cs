    Expression<Func<InvoicesView, DateTime>> groupingExpr = c => c.InvoiceDate.Date;
    
    if (period == periodicity.Weekly)
    {
      groupingExpr = c => c.InvoiceDate.Date.AddDays(-(double)c.InvoiceDate.DayOfWeek);
    }
    else if (period == periodicity.Monthly)
    {
      groupingExpr = c => new DateTime(c.InvoiceDate.Year,c.InvoiceDate.Month ,1);
    }
    else if (period == periodicity.Quarterly)
    {
      groupingExpr = c => new DateTime(c.InvoiceDate.Year, c.InvoiceDate.Month - (c.InvoiceDate.Month % 3) +1, 1);
    }
    else if (period == periodicity.Anual
    {
      groupingExpr = c => new DateTime(c.InvoiceDate.Year, 1, 1);
    }
    var TotalGroupedInvoices = entidades.InvoicesView 
      .GroupBy(groupingExpr)
      .Select(grouped => new {
        period = grouped.Key,
        Total = grouped.Sum(c => c.Total)   
      });
