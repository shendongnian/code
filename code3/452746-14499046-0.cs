     List<tbl_GameConfig> gameConfig = new List<tbl_GameConfig>();
     using (Entities con = new Entities())
      {
           gameConfig = con.tbl_GameConfig.Where(p => p.fk_GameTypeId == gameTypeId).ToList<tbl_GameConfig>();
      }       
