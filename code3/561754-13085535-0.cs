    private void ListView1_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
    {
        foreach ( ListViewItem item in ListView1.SelectedItems)
		{
			textbox1.Text = item.SubItems[1].Text;
		}
    }
