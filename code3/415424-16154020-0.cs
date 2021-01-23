        private bool trackbarMouseDown = false;
        private bool trackbarScrolling = false;
        private void trackbarCurrentPosition_Scroll(object sender, EventArgs e)
        {
            trackbarScrolling = true;
        }
        private void trackbarCurrentPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackbarMouseDown == true && trackbarScrolling == true)
                Playback.SetPosition(trackbarCurrentPosition.Value);
            trackbarMouseDown = false;
            trackbarScrolling = false;
        }
        private void trackbarCurrentPosition_MouseDown(object sender, MouseEventArgs e)
        {
            trackbarMouseDown = true;
        }
