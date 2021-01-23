    var countries = (new[] {
        new { Name = "United States", Abbr = "US", Currency = "$" },
        new { Name = "Canada", Abbr = "CA", Currency = "$" },
     });
     List<string> names = new List<string>();
     countries.ToList().ForEach(x => { names.Add(x.Name); });
