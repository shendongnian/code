    gameResults = gameResults.GroupBy(t => new {t.ContendersName, t.Year}).Select(
                       g => new PivotTeamResult()
                       {
                           ContendersName = g.Key.ContendersName,
                           Year = g.Key.Year,
                           Wins = g.Sum(x => x.Wins)                          
    
                       }).ToList();
