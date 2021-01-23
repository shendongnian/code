    var teamResults = matches.SelectMany(m => new[] {
            new {
                MatchDate = m.MatchDate,
                Team = m.TeamA,
                Won = m.TeamAGoals > m.TeamBGoals },
            new {
                MatchDate = m.MatchDate,
                Team = m.TeamB,
                Won = m.TeamBGoals > m.TeamAGoals }
        });
