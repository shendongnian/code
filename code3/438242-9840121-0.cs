    for (int i = 0; i < recent_cases.Count; ++i)
    {
        var mi= new MenuItem();
        mi.Header = recent_cases[i];
        mi.Click += new EventHandler(MenuItem_Click);
        MenuItem_OpenRecent.Items.Add(mi);                    
    }
    
    ....
    void MenuItem_Click(object sender, EventArgs e)
    {
        var mi= sender as MenuItem;
        //Do stuff with your file
    }
