      var bdates = new List<Tuple<string, DateTime>>();
      bdates.Add(Tuple.Create("Sally", new DateTime(1962, 1)));
      bdates.Add(Tuple.Create("John", new DateTime(1988, 2)));
      bdates.Add(Tuple.Create("Benny", new DateTime(1988, 1)));
      
      dates.OrderBy(d => d.Month);
