    public static void PlayMessageFailedSound()
        {
            var s = Song.FromUri("MessageFailed", new Uri(@"Resources/Alert_nudge.wma", UriKind.Relative));
            FrameworkDispatcher.Update();
            MediaPlayer.Play(s);
        }
