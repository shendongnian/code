        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                
                timer1.Interval = 100;
                timer1.Start();
                timer1.Enabled = true;   
                timer1.Tick += timer1_Tick;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /// method to play video list items
            myFuntiontoPlayVideo();
            timer1.Enabled = false;
        }     
