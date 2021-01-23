    List<AlbumTag> query = (from ps in dbSet.PhotoSet
                             where ps.Album.UserId = userId
                             group new { album, tag } by new { ps.Album.Title, ps.PhotoTag.Tag.Name } into resultSet
                             orderby resultSet.Key.Name
                             select new AlbumTag()
                             {
                               AlbumTitle = resultSet.Key.Title,
                               TagName = resultSet.Key.Name,
                               TagCount = resultSet.Count()
                             }).ToList();
