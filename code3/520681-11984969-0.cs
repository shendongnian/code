    private bool AllowToLoseFocus = true;
    
    private void MyListView_Leave(object sender, EventArgs e)
    {
       if(!AllowToLoseFocus)
            MyListView.Focus();
    }
    private void MyListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        AllowToLoseFocus = false;
        //do stuff here
        AllowToLoseFocus = true;
    }
    
