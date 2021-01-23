    var sql = @"SELECT AL.AlbumId, AL.Title, AL.Price, AL.AlbumArtUrl, GE.GenreId, GE.Name, GE.Description, AR.ArtistId, AR.Name FROM Album AL INNER JOIN Artist AR ON AR.ArtistId = AL.ArtistId INNER JOIN Genre GE ON GE.GenreId = AL.GenreId";
                using (var conn = connFactory.OpenConnection())
                {
                    var res = conn.Query<Album, Genre, Artist, Album>(sql, (album, genre, artist) =>
                    {
                        album.Genre = genre;
                        album.Artist = artist;
                        return album;
                    }, splitOn: "GenreId,ArtistId");
                }
