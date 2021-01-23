    public static void SomeLoop()
    {
        using(var db = new ArcadeContext())
        {
            var changeRecs = db.ArcadeGameRanks.Where(c => c.Date == today);
            foreach (var rankRecord in changeRecs)
            {
                var rank = SomeMethod(rankRecord.GameID);
                UpdateGamesCatRank(rankRecord.GameID, rank, db);
            }
        }
    }
    
    public static void UpdateGamesCatRank(int gameID, int catRank, ArcadeContext db)
    {
        db.ExecuteCommand("UPDATE ArcadeGame SET CategoryRank = " + catRank + " WHERE ID = " + gameID);
    }
