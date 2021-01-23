    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    	{
    	    // Acquire SelectedItems reference.
    	    var selectedItems = listView1.SelectedItems;
    	    if (selectedItems.Count > 0)
    	    {
    		// Display text of first item selected.
    		this.Text = selectedItems[0].Text;
    	    }
    	    else
    	    {
    		// Display default string.
    		this.Text = "Empty";
    	    }
    	}
