    void GridControlBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Clicks != 2)
        {
            StartDragging();
        }
    }
