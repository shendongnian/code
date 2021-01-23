    private bool listbox3job()
    {
    
        AxWMPLib.AxWindowsMediaPlayer axWmp = wfh.Child as AxWMPLib.AxWindowsMediaPlayer;
        WMPLib.IWMPPlaylist playlist = axWmp.newPlaylist("myPlaylist", string.Empty);
    
        foreach (var selected in listBox1.Items)
        {
            string s = selected.ToString();
            if (listBox3Dict.ContainsKey(s))
            {
                WMPLib.IWMPMedia temp = axWmp.newMedia(listBox3Dict[s]); //Load media from URL. 
                playlist.appendItem(temp); //Add song to playlist.
            }
        }
        axWmp.settings.autoStart = true; //not necessary
        axWmp.currentPlaylist = playlist; //Set media player to use the playlist.
        return true;
    }
