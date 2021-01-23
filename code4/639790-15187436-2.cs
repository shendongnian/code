    foreach (var c in tabControl1.SelectedTab.Controls)
    {
        if (c is WebBrowser)
        {
            ((WebBrowser)c).Navigate(browserURL);
        }
    }
