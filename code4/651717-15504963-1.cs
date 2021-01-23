    private bool isSelected = false;
    private void url_MouseDown(object sender, MouseEventArgs e)
    {
        url.ReadOnly = false;
        if (isSelected)
        {
            url.DeselectAll();
        } 
        else 
        {
            url.SelectAll();
        }
        isSelected = !isSelected;
    }
