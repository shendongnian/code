    int gamePlayersInSkillRange = 0;
    foreach (Player gamePlayer in game.Allies.Players)
    {
        // Compare beoth skill values. If they are in a certain range increase the counter.
        if (Math.Abs(teamPlayer.Skill - gamePlayer.Skill) <= 200) // The range is currently set for 200, but I want to make it variable later.
            gamePlayersInSkillRange++;
    }
