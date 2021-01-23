    List<int> clubIds = new List<int> { 1, 2, 3};
    var prevClubs = from player in players
                    where player.previousClubs.Any(m => clubIds.Contains(m.ID))
                    select new HistoryOfPlayer {
                       Player = player, 
                       Clubs = player.previousClubs
                                     .Where(m => clubIds.Contains(m.ID))
                                     .Select(c => c.Name) 
                    };
