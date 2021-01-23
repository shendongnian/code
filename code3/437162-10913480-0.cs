    public List<MusicEntry> GetMusicLibrary()
    { 
      List<MusicEntry> entries; 
      IWMPPlaylist mediaList = null; 
      IWMPMedia mediaItem; 
      
      try
      { 
        // get the full audio media list 
        mediaList = media.getByAttribute("MediaType", "Audio"); 
        entries = new List<MusicEntry>(mediaList.count); 
        
        for (int i = 0; i < mediaList.count; i++) 
        {
          mediaItem = mediaList.get_Item(i);
          
          // create the new entry and populate its properties
          entry = new MusicEntry() 
          { 
            Title = GetTitle(mediaItem), 
            Album = GetAlbum(mediaItem), 
            Artist = GetArtist(mediaItem), 
            TrackNumber = GetTrackNumber(mediaItem), 
            Rating = GetRating(mediaItem), 
            FileType = GetFileType(mediaItem) 
          }; 
          
          entries.Add(entry); 
        } 
      } 
      finally 
      { 
        // make sure we clean up as this is COM 
        if (mediaList != null) 
        {
          mediaList.clear(); 
        } 
      } 
      
      return entries;
    }
