    private bool descendingSongTitleSort = false;
    private bool descendingArtistSort = false;
    private void artistButtonClicked(object sender, EventArgs args)
    {
        songResultBox.Items.Clear();
        List<Song> items = null;
        if(descendingArtistSort)
        {
            items = yourSongList.OrderByDescending(song => song.Artist).ToList(); 
        } 
        else 
        {
            items = yourSongList.OrderBy(song => song.Artist).ToList();
        }
        foreach(Song s in items)
        {
            songResultBox.Items.Add(s); 
        }
        descendingArtistSort = !descendingArtistSort;
        descendingSongTitleSort = false;
    }
