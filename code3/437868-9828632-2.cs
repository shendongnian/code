      var bdates = new List<Tuple<string, DateTime?>>();
      bdates.Add(Tuple.Create("Sally", (DateTime?)new DateTime(1962, 1, 1)));
      bdates.Add(Tuple.Create("John", (DateTime?)new DateTime(1988, 2, 1)));
      bdates.Add(Tuple.Create("Benny", (DateTime?)new DateTime(1988, 1, 1)));
      bdates.Add(Tuple.Create("Joe", (DateTime?)new DateTime(1988, 1, 2)));
      bdates.Add(Tuple.Create("Bob", (DateTime?)null));
      var v = bdates
        .Where(bdate => bdate.Item2.HasValue)
        .OrderBy(bdate => bdate.Item2.Value.Day)
        .OrderBy(bdate => bdate.Item2.Value.Month);
