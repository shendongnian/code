    var options = new QueryOptions(CommonFileQuery.OrderByMusicProperties, new List<string> { ".mp3" });
    options.SetThumbnailPrefetch(ThumbnailMode.MusicView, 256, ThumbnailOptions.UseCurrentScale);
    
    var query = KnownFolders.MusicLibrary.CreateFileQueryWithOptions(options);
    var files = await query.GetFilesAsync();
    
    foreach (var file in files)
    {
        /* Access MP3s */
    }
