	private void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if(((DataGridView)sender).CurrentCell.ColumnIndex == 0) //Assuming 0 is the index of the ComboBox Column you want to show
		{
			ComboBox cb = e.Control as ComboBox;
			if (cb!=null)
			{
				cb.SelectionChangeCommitted -= new EventHandler(cb_SelectedIndexChanged);
				// now attach the event handler
				cb.SelectionChangeCommitted += new EventHandler(cb_SelectedIndexChanged);
			}
		}
	}
