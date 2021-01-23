    public void AddPlayList(string playlistname)
    {
        this.playlistviewbar.Items.Add(playlistname);
    }
    public string[] GetPlayLists()
    {
        return this.playlistviewbar.Items;  // converting to strings if necessary.
    }
