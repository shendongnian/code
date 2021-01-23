    public void KeyDownEvent_(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F1)
            player.Play(lbPlaylist.Items[lbPlaylist.Items.IndexOf(lbPlaylist.SelectedItem)].ToString());// passed string
        if (e.Key == Key.F3)
            search.Find(tbSearch.Text);
        if (e.Key == Key.F5)
        {
            foreach (Tagi d in search.dictPesmi.Values)
            {
                if (!lbPlaylist.Items.Contains(d.Name))
                    lbPlaylist.Items.Add(d.Name);
            }
            // add this line to use the data just collected:
            player.dictPesmi = search.dictPesmi;
        }
        if (e.Key == Key.F9)
        {
        }
    }
