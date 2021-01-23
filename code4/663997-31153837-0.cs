    void timelineThumb_MouseMove(object sender, MouseEventArgs e)
    {
           
         if (e.LeftButton == MouseButtonState.Pressed)
         {
             var thumb = sender as Thumb;
             Point pos = e.GetPosition(uiVideoPlayerTimelineSlider);
             double d = 1.0d / uiVideoPlayerTimelineSlider.ActualWidth * pos.X;
             uiVideoPlayerTimelineSlider.Value = uiVideoPlayerTimelineSlider.Maximum * d;
                
         }
    }
