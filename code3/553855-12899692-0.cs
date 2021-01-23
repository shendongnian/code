    schedule_tournament(new List<string> { "A", "B", "C" });
    schedule_tournament(new List<string> { "A", "B", "C", "D", });
    schedule_tournament(new List<string> { "A", "B", "C", "D", "E" });
    schedule_tournament(new List<string> { "A", "B", "C", "D", "E", "F" });
    schedule_tournament(new List<string> { "A", "B", "C", "D", "E", "F", "G" });
    ...
    
    private void schedule_tournament(List<string> teams)
    {            
        List<string> games = new List<string>();
        List<string> rounds = new List<string>();
                
        // get all possible games
        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = i + 1; j < teams.Count; j++)
            {
                string game_name = string.Format("{0}{1}", teams[i], teams[j]);
                if (!games.Contains(game_name)) games.Add(game_name);
            }
        }
    
        // allocate games to rounds
        for (int i = 0; i < games.Count; i++)
        {
            bool allocated = false;
            for (int j = 0; j < rounds.Count; j++)
            {
                string team_1 = games[i].Substring(0, 1);
                string team_2 = games[i].Substring(1, 1);
                if (!rounds[j].Contains(team_1) && !rounds[j].Contains(team_2))
                {
                    rounds[j] += " - " + games[i];
                    allocated = true;
                    break;
                }
            }
            if (!allocated)
            {
                rounds.Add(games[i]);
            }
        }
        Console.WriteLine("{0} teams, play {1} games in {2} rounds", teams.Count, games.Count, rounds.Count);
        for (int i = 0; i < rounds.Count; i++) Console.WriteLine("Round {0}: {1}", i + 1, rounds[i]);
    }
