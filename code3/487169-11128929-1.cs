    playerViewModelList.AddRange(playerData.Select(d => new PlayersViewModel {
        PicPath = d.Tied.ToString(),
        PlayerID = (int)d.ID,
        PlayerName = d.TeamName
    }));
