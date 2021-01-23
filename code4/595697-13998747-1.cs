    // Loop through each player in the Automatch queue.
    foreach (Team team in match.TeamsInQueue)
    {
        // Loop through every game in the Atomatch queue.
        foreach (Game game in match.AvailableGames)
        {
            bool allInSkillRange = team.Players.All(t =>
                game.Allies.Players.All(g => Math.Abs(t.Skill - g.Skill) <= 200));
            if(allInSkillRange)
            {
                // ToDo: Implement join process here.
            }
        }
    }
