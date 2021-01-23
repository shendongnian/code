    public IEnumerable<HighScoreViewModel> GetHighScores<TKey>(Func<Player, TKey> highscore)
    {
      return _allPlayers
        .OrderByDescending(highscore)
        .Take(8)
        .Select(x => new HighScoreViewModel
        {
            Points = highscore(x),
            PointsText = "FG: " + highscore(x),
            ImageUrl = x.Facebook.SmallImageUrl,
            DisplayName = x.DisplayName,
        }).ToList();
    }
