    Player = new WMPLib.WindowsMediaPlayer();
                Player.PlayStateChange +=
                    new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
                Player.MediaError +=
                    new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
                Player.URL = "FC.wav";
                Player.controls.play();
       private void Player_PlayStateChange(int NewState)
       {
           if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
           {
              
           }
       }
    
       private void Player_MediaError(object pMediaObject)
       {
           MessageBox.Show("Cannot play media file.");
           this.Close();
       }
