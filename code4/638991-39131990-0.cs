      var Games = context.Games.Select(a => new GameModel
            {
                // carries type1 results
                Members = a.UsersInGames.Where(b => b.GameID == a.ID && b.StatusID == 1).Select(c => new Member
                {
                    ID = c.UserID,
                    email = c.UserInfo.EmailAddress,
                    screenName = c.UserInfo.ScreenName
                })),
                 //You need to create this temporary carrier to carry type 2 results
                 MembersOfType2 = a.Teams.Where(b => b.GameID == a.ID).SelectMany(b => b.UsersInTeams.Where(c => c.StatusID == 1)).Select(d => new Member
                    {
                        ID = d.UserID,
                        email = d.UserInfo.EmailAddress,
                        screenName = d.UserInfo.ScreenName
                    })))
                })
            }
