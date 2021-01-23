    WMPLib.WindowsMediaPlayer a= new WMPLib.WindowsMediaPlayer();
    private void playmp3(string path, string playState)
    {
        
        a.URL = path;
        if(playstate.Equals("Play))
        {
        a.controls.play();
        }
        else if (playState.Equals("Stop"))
        {
          a.controls.stop();
        }
    }
