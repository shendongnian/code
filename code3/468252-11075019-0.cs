    media.MediaOpened += new System.Windows.RoutedEventHandler(media_MediaOpened);
    			media.LoadedBehavior = MediaState.Manual;
    			media.UnloadedBehavior = MediaState.Manual;
    			media.Play();
    
    void media_MediaOpened( object sender, System.Windows.RoutedEventArgs e )
    		{
    			progress.Maximum = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
    			timer.Start();
    			isPlaying = true;
    		}
