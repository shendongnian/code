    IQueryable<Score> query = db.ArcadeScores.Where(c => c.GameID == gameID);
    
    switch(type)
    {
        case HighScoreType.ScoreRank:
            query = query.Where(c => c.ScoreRank > 0).OrderBy(c => c.ScoreRank);
            break;
        case HighScoreType.UserRank:
            query = query.Where(c => c.UserRank > 0).OrderBy(c => c.UserRank);
            break;
    }
    if (skip.HasValue && take.HasValue)
       query = query.Skip(skip.Value).Take(take.Value);
    return query.ToList();
