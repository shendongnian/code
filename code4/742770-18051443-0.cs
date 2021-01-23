    var result = (Companies
                .Where(c => c.CompanyName.StartsWith("Apple"))
                .Select(c => new
                {
                    Tick = c.Ticker.Trim(),
                    Address = c.Address.Trim()
                })).ToList();
                
     var result1=result
                .Where(c=>c.CompanyName.Trim().Equals("Apple")) 
                .Select(c => c);
