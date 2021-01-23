    public int CreateNewSong(String name,String songTitle,String album)
    {
        using(var context = new Myentities())
        {
            Song theNewSong = new Song()
            Artist refer = context.Artists.Single(o => o.ArtistName == name);
    
            Album album = context.Albums.Single(o => o.AlbumName == album);
    
            theNewSong.SongTitle = songTitle;
    
            theNewSong.Artist_ArtistID = refer.ArtistID;
            theNewSong.Album_AlbumID = album.AlbumID;
            context.Songs.AddObject(theNewSong);
            context.SaveChanges();
            return theNewSong.SongID;
        }
    }
