    Windows.Storage.StorageFile file = null;
    mediaElement player = new MediaElement();
        async Task PlayAsync()
        {
            if (file == null)
            {
                file = await OpenFileAsync();
                try { player.MediaOpened -= Player_MediaOpenedAsync; } catch { }
                try { player.MediaEnded -= Player_MediaEnded; } catch { }
                try { player.MediaFailed -= Player_MediaFailed; } catch { }
                player.MediaOpened += Player_MediaOpenedAsync;
                player.MediaEnded += Player_MediaEnded;
                player.MediaFailed += Player_MediaFailed;
                
                player.SetPlaybackSource(MediaSource.CreateFromStorageFile(file)); //Works with media playback..
                //player.Source = new Uri(mediasource, UriKind.RelativeOrAbsolute); //Doesn't work with media playback for some reason..
                Playing = true;
                Paused = false;
            }
            else
            {
                if (Paused)
                {
                    player.Play();
                    Paused = false;
                }
                else
                {
                    player.Pause();
                    Paused = true;
                }
            }
        }
        async Task<StorageFile> OpenFileAsync()
        {
            try
            {
                var ofd = new FileOpenPicker();
                ofd.FileTypeFilter.Add("*");
                return await ofd.PickSingleFileAsync();
            }
            catch { }
            return null;
        }
