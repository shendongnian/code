    List<stats> myStats = GetStatsList()
        .GroupBy(s => new{ s.Date, s.Team})
        .Select(g => new stats
          {
                Date = g.Key.Date,
                Team = g.Key.Team,
         }).ToList();
