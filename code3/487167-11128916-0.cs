    playerViewModelList = playerData.Select(dataTeam => new PlayersViewModel
                                            {
                                                PicPath = dataTeam.Tied.ToString(),
                                                PlayerID = (int)dataTeam.ID,
                                                PlayerName = dataTeam.TeamName
                                            }).ToList();
