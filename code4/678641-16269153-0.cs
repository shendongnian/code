      gameResults =
                    gameResults.GroupBy(t => new{t.ContendersName, t.Year})
                    .OrderBy(g => g.Key.ContendersName)
                    .Select(g => new PivotTeamResult()
                       {
                           ContendersName = g.Key.ContendersName,
                           Year = g.Key.Year,
                           Wins = g.Sum(x => x.Wins)                          
                       }).ToList();
