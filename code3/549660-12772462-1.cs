    void player_StatusChange(object sender, EventArgs e)
    {
        if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
        {
            playingTimer.Enabled = true;
        }
        else
        {
            playingTimer.Enabled = false;
        }
    }
