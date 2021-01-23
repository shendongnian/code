         var relatedDevelopers = currentVideo.Games.SelectMany( g => g.Developers ).Select( g => g.DeveloperID ).ToArray();
         var relatedPublishers = currentVideo.Games.SelectMany( g => g.Developers ).Select( g => g.DeveloperID ).ToArray();
         var relatedGenres = currentVideo.Games.SelectMany( g => g.Developers ).Select( g => g.DeveloperID ).ToArray();
            
         //This is the piece I am having trouble with!
         var relatedGames = from game in ugdb.Games
                            where game.Developers.Any( d => relatedDevelopers.Contains(d.DeveloperID) )
                            || game.Publishers.Any( d => relatedPublishers.Contains(d.PublisherID))
                            || game.Genres.Any( d => relatedGenres.Contains(d.GenreID) )
                            select game;
