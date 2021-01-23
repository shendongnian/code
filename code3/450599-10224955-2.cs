    public int CreateNewSong(String name, String songTitle, String album)
    {
        using(var context = new Myentities())
        {
            Album album = context.Albums.Single(o => o.AlbumName == album);
            Artist refer = context.Artists.Single(o => o.ArtistName == name);
    	    Song theNewSong = new Song {
                                          SongTitle = songTitle,
                                          Artist = refer 										
                                       };
    									
    	    theNewSong.Albums.Add(album);     
            context.Songs.AddObject(theNewSong);
            context.SaveChanges();
            return theNewSong.SongID;
        }
    }
