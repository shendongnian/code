    IEnumerable<FixedLineSummary> summaries = summary
       .Select(s => new FixedLineSummary
       {
            CustomerId = s.CustomerId,
            CustomerName = s.CustomerName,
            NumberOfLines = s.NumberOfLines,
            SiteName = s.SiteName
       })
       .ToList();
