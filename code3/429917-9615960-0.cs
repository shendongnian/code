    foreach (var manager in managers)
                        {
                            var tennisClubToreference = new TennisClub()
                               {
                                    Id = manager.TennisClubID;
                               }
        
                            manager.TennisClubs.add(tennisClubToreference);
                        }
