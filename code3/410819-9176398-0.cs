            protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            switch (playState)
            {
                case PlayState.Stopped:
                    track.BeginEdit();
                    track.Tag = track.Source.OriginalString;
                    track.Source = new Uri("http://127.0.0.1", UriKind.Absolute);
                    track.EndEdit();
                    
                    player.Track = track;
                    break;
    
            protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            switch (action)
            {
                case UserAction.Play:
                    if (player.PlayerState != PlayState.Playing)
                    {
                        try
                        {
                            player.Play();
                        }
                        catch(Exception)
                        {
                            track.BeginEdit();
                            track.Source = new Uri(player.Track.Tag, UriKind.Absolute);
                            track.EndEdit();
                            player.Track = track;
                            player.Play();
                        }
                    }
                    break;
                case UserAction.Stop:
                case UserAction.Pause:
                    if (player.Track.Source.OriginalString != "http://127.0.0.1/")
                    {
                        player.Stop();
                    }
                    break;
