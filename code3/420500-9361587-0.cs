    Expression<Func<InvoicesView, DateTime>> groupingExpr = 
      (period == periodicity.Daily) ? c => c.InvoiceDate.Date : 
      period == periodicity.Weekly ? c => c.InvoiceDate.Date.AddDays(-(double)c.InvoiceDate.DayOfWeek) : 
      period == periodicity.Monthly ? c => new DateTime(c.InvoiceDate.Year,c.InvoiceDate.Month ,1) : 
      period == periodicity.Quarterly ? c => new DateTime(c.InvoiceDate.Year, c.InvoiceDate.Month - (c.InvoiceDate.Month % 3) +1, 1) : 
      period == periodicity.Anual ? c => new DateTime(c.InvoiceDate.Year, 1, 1) :
      c => c.InvoiceDate.Date;
    var TotalGroupedInvoices = entidades.InvoicesView 
      .GroupBy(groupingExpr)
      .Select(grouped => new {
        period = grouped.Key,
        Total = grouped.Sum(c => c.Total)   
      });
