    private bool descendingSongTitleSort = false;
    private bool descendingArtistSort = false;
    // Artist button clicked event
    private void artistButtonClicked(object sender, EventArgs args)
    {
        Func<Song, IComparable> sortProp = (song => song.Artist);
        sortListBox(songResultBox, descendingArtistSort, sortProp);
        descendingSongTitleSort = false;
        descendingArtistSort = !descendingArtistSort;
    }
    // Title button clicked event
    private void titleButtonClicked(object sender, EventArgs args)
    {
        Func<Song, IComparable> sortProp = (song => song.Title);
        sortListBox(songResultBox, descendingSongTitleSort, sortProp);
        descendingSongTitleSort = !descendingSongTitleSort;
        descendingArtistSort = false;
    }
    // Sorting function
    private void sortListBox(
        ListBox box, 
        bool descending, 
        Func<Song, IComparable> sortProperty)
    {
        List<Song> items = new List<Song>();
        foreach (Object o in box.Items)
        {
            Song s = o as Song;
            items.Add(s);
        }
        box.Items.Clear();
        if(descending)
        {
            items = items.OrderByDescending(sortProperty).ToList(); 
        } 
        else 
        {
            items = items.OrderBy(sortProperty).ToList();
        }
        foreach(Song s in items)
        {
            box.Items.Add(s); 
        }
    }
