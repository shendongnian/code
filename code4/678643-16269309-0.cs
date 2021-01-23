    gameResults =
                    gameResults.GroupBy(t => new{t.ContendersName, t.Year})
                    .OrderBy(g => g.Key.ContendersName)
                    .ThenBy(g => g.Key.Year)
                    .Select(g => new PivotTeamResult()
                       {
                           ContendersName = g.Key.ContendersName,
                           Year = g.Key.Year,
                           Wins = g.Sum(x => x.Wins)                          
                       }).ToList();
