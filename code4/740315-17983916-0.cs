    //Local reference to the file
    TagLib.File file = TagLib.File.Create("band1.mp3");
    
    //Get the file metadata
    Console.WriteLine("Tags on disk: " + file.TagTypesOnDisk);
    Console.WriteLine("Tags in object: " + file.TagTypes);
               
    Write ("Grouping", file.Tag.Grouping);
    Write ("Title", file.Tag.Title);
    Write ("Album Artists", file.Tag.AlbumArtists);
    Write ("Performers", file.Tag.Performers);
    Write ("Composers", file.Tag.Composers);
    Write ("Conductor", file.Tag.Conductor);
    Write ("Album", file.Tag.Album);
    Write ("Genres", file.Tag.Genres);
    Write ("BPM", file.Tag.BeatsPerMinute);
    Write ("Year", file.Tag.Year);
    Write ("Track", file.Tag.Track);
    Write ("TrackCount", file.Tag.TrackCount);
    Write ("Disc", file.Tag.Disc);
    Write ("DiscCount", file.Tag.DiscCount);
