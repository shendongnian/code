    public static void EnsureGridRowIsSelectedAndVisible(DataGridViewRow row)
    {
	    if (row == null)
		    return;
	    row.Selected = true;
	    // Center the item in the display
	    row.DataGridView.FirstDisplayedScrollingRowIndex = 
            Math.Max(row.Index - Convert.ToInt32(row.DataGridView.DisplayedRowCount(false) / 2), 0);
    }
