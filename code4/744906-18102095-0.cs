    using(MediaLibrary library = new MediaLibrary())
    {
    	foreach(var song in library.Songs)
    	{
    		debug.WriteLine("Name: " + song.Name);
    		debug.WriteLine("Artist: " + song.Artist.Name);
    		debug.WriteLine("Album: " + song.Album.Name);
    	}
    }
