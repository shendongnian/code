    private void VideoPlayer_MarkerReached(object sender, TimelineMarkerRoutedEventArgs e)
    {
        // you can check the type if you want to be safe
        if (e.Marker.Type.Equals("ForcePause"))
        {
            VideoPlayer.Pause();
        }
    }
