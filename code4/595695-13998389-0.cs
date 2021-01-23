    foreach(Team team in match.TeamsInQueue)
    {
        if(team.Players.Insersect(match
               .SelectMany(m => m.AvailableGames, g=> g.Allies.Players), 
                new PlayerSkillComparer().Count() == team.Players.Count()) {
             // ToDO: Implement join process here.
        }
    }
