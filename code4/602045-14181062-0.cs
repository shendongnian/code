    public static IEnumerable<string> PairPlayers(List<string> players)
    {
        for (int i = 0; i < players.Count - 1; i++)
        {
            for (int j = i + 1; j < players.Count; j++)
            {
                yield return players[i] + " " + players[j];
            }
        }
    }
