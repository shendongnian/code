    private void PlayTrack(BackgroundAudioPlayer player)
    {
           var track = new AudioTrack(
                        new Uri("http://m1.onweb.gr/1055rock"),
                        "Online",
                        "Music",
                        string.Empty,
                        null,
                        string.Empty,
                        EnabledPlayerControls.Pause);
            if (player != null)
            {
                player.Track = track;
            }
    }
