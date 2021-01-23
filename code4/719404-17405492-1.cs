    private IEnumerable<ArcadeScore> GetArcadeOverallScore(int gameId)
    {
       return db.ArcadeScores.Where(c => c.GameID == gameID && c.ScoreRank > 0)
                                        .OrderBy(c => c.ScoreRank)
    }
    
    private IEnumerable<ArcadeScore> GetArcadeUserScore(int gameId)
    {
       return db.ArcadeScores.Where(c => c.GameID == gameID && c.UserRank > 0)
                                    .OrderBy(c => c.UserRank)
    }
