        //
        // Opens and plays song titled "[Cars]You_Might_Think.mp3"
        // in the 80s folder.
        //
        // IMPORTANT: the example song must be in the user's Music
        // folder or SD card to be found.   Also, the app manifest
        // must have 'Music Library' capabilities enabled.
        //
        // 
        //
        async void OpenAndPlayAwesomeSongFromThe80s()
        {            
            Windows.Storage.StorageFolder folder = KnownFolders.MusicLibrary;
            StorageFile song = await folder.GetFileAsync("80s\\[Cars]You_Might_Think.mp3");
            if (song != null)
            {
                IRandomAccessStream stream = await song.OpenAsync(Windows.Storage.FileAccessMode.Read);
                if (stream != null)
                {
                    mediaElement = new MediaElement();
                    mediaElement.SetSource(stream, song.ContentType);
                    mediaElement.Play();
                }
            }
        }
