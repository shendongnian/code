    /// <summary>
    /// Plays a full round, one match per team.
    /// </summary>
    void PlayRound(List<Team> teams)
    {
        List<Team> played = new List<Team>(); // keep track of teams in the outer loop
        foreach (Team teamA in teams)
        {
            foreach (Team teamB in teams)
            {
                if (teamA == teamB || played.Contains(teamB))
                    continue;
                else
                    PlayMatch(teamA, teamB);
            }
            played.Add(teamA); // add outer loop team to ensure one match per pairing
        }
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
