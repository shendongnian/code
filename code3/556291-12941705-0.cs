    public IEnumerable<HighScoreViewModel> GetHighScores(Func<Player, double> highscore)
    {
        return _allPlayers
            .OrderByDescending(highscore)
            .Take(8)
            .Select(x => new HighScoreViewModel
            {
                // Magic?
                Points = highScore(x),
                PointsText = "FG: " + x.BestHighScore,
                //ImageUrl = x.Facebook.SmallImageUrl,
                DisplayName = x.DisplayName,
            }).ToList();
    }
