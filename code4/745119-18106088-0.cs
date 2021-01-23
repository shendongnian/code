    /// <summary>
    /// Plays a full round, one match per team.
    /// </summary>
    void PlayRound(List<Team> teams)
    {
        foreach (Team teamA in teams)            
            foreach (Team teamB in teams)                
                if (teamA == teamB)
                    continue;
                else
                    PlayMatch(teamA, teamB);
    }
    /// <summary>
    /// Plays a match.
    /// </summary>
    void PlayMatch(Team teamA, Team teamB)
    {
        int scoreA = rand.Next();
        int scoreB = rand.Next();
        if (scoreA > scoreB)
        {
            teamA.Win();
            teamB.Lose();
        }
        else if (scoreA == scoreB)
        {
            teamA.Draw();
            teamB.Draw();
        }
        else
        {
            teamB.Win();
            teamA.Lose();
        }
    }
