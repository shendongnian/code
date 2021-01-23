    private Timer _scrollingTimer = null;
    
    private void trackbar_Scroll(object sender, EventArgs e)
    {
        if (_scrollingTimer == null)
        {
            // Will tick every 500ms (change as required)
            _scrollingTimer = new Timer() 
            {
                    Enabled = false,
                    Interval = 500,
                    Tag = (sender as TrackBar).Value
            };
            _scrollingTimer.Tick += (s, ea) =>
            {
                // check to see if the value has changed since we last ticked
                if (trackBar.Value == (int)_scrollingTimer.Tag)
                {
                    // scrolling has stopped so we are good to go ahead and do stuff
                    _scrollingTimer.Stop();
                    
                    // Do Stuff Here . . .
    
                    _scrollingTimer.Dispose();
                    _scrollingTimer = null;
                }
                else
                {
                    // record the last value seen
                    _scrollingTimer.Tag = trackBar.Value;
                }
            };
            _scrollingTimer.Start();
        }
    }
