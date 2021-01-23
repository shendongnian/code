    var songsByUser = songs.UserSongs
                           .GroupBy(song => song.UserId, song => song.SongId)
                           .AsEnumerable()
                           .Select(g => new SongsForUser { User = g.Key,
                                                           Songs = g.ToList() });
