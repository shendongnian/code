    public FrmTest()
    {
        list.ItemSelectionChanged += list_ItemSelectionChanged;
    }
    private bool changing;
    private void list_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (changing)
            return;
        if (e.Item == nonSelectableListItem) 
        {
            changing = true;
            nonSelectableListItem.Selected = false;
            changing = false;
        }
    }
