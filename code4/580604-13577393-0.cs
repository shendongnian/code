    private Song song;
    string musicUrl = string.Format("/Bird Calls;component/Crow.mp3", music);
    song = Song.FromUri("name", new Uri(musicUrl, UriKind.Relative));
    FrameworkDispatcher.Update();
    MediaPlayer.IsRepeating = true;
    MediaPlayer.Play(song);
