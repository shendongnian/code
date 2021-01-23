     var relatedGames = from game in ugdb.Games.ToList()
                        where game.Developers.Any(d => relatedDevelopers.Any(r => r.DeveloperID == d.DeveloperID))
                        || game.Publishers.Any(d => relatedPublishers.Any(r => r.PublisherID == d.PublisherID))
                        || game.Genres.Any(d => relatedGenres.Any(r => r.GenreID == d.GenreID))
                        select game;
