      playerViewModelList = playerData.ConvertAll(dataTeam => new PlayersViewModel
      {
        PicPath = dataTeam.Tied.ToString(),
        PlayerID = (int)dataTeam.ID,
        PlayerName = dataTeam.TeamName
      }); 
