    yourListView.ItemSelectionChanged += yourListView_ItemSelectionChanged;
    
    private void yourListView_ItemSelectionChanged(
        object sender,
        ListViewItemSelectionChangedEventArgs e)
    {
        if (e.Item.BackColor == Color.LightGray)
        {
            e.Item.Selected = false;
            e.Item.Focused = false;
        }
    }
