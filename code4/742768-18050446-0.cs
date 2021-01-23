    var paddedName = "Apple".PadRight(50);
    var result = Companies
     .Where(c => c.CompanyName.Trim().Equals(paddedName))
     .Select(c => new {
         Tick = c.Ticker.Trim(),
         Address = c.Address.Trim()
     });
