    //Possible SQL for creating the view
    CREATE VIEW vw_GameData AS 
    SELECT g.GameId, g.Region, p.AccountId, etc...
    FROM Game g JOIN Player p ON (g.GameId = p.GameId AND g.Region = p.Region)
    JOIN Statistic s ON (s.GameId = p.GameId AND s.RegionId = p.RegionId AND s.AccountId = p.AccountId)
