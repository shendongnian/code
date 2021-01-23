    private void url_MouseDown(object sender, MouseEventArgs e)
    {
        url.ReadOnly = false;
        if (IsDeselected)
        {
            url.SelectAll();
        } 
        else 
        {
            url.DeselectAll();
        }
    }
