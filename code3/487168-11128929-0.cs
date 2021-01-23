    playerData.ForEach(d => playerViewModelList.Add(new PlayersViewModel {
        PicPath = d.Tied.ToString(),
        PlayerID = (int)d.ID,
        PlayerName = d.TeamName
    }));
