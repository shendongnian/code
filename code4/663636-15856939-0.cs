    public void saveGameResult(GameResult gameResult, .... more arguments ....)
    {
        using (var db = new GameContext())
        {
            db.GameResults.Add(gameResult);
            gameResult.Location = location;
            gameResult.Competition = competition;
            gameResult.ContenderFirst = firstContender;
            gameResult.ContenderSecond = secondContender;
            db.SaveChanges();
        }
    }
