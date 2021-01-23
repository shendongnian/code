    private void ContextMenuItemClick(object sender, EventArgs e)
    {
        var selectedItem = (MenuItem)sender;
        switch(selectedItem.Text)
        {
            case "New" : //do some new stuff
                break;
            case "Close": //do some closing stuff
                break;
        }
    }
