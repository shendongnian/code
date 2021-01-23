    var summary = from r in result 
                  let k = new {r.CustomerId, CustomerName = r.CompanyName, r.SiteName}
                  group r by k into t
                  select new FixedLineSummary
                  {
                      CustomerId = t.Key.CustomerId,
                      CustomerName = t.Key.CustomerName,
                      SiteName = t.Key.SiteName,
                      NumberOfLines = t.Sum(r => r.lines)
                  };
