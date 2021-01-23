    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
    	if (e.ClickedItem.BackColor != Color.Blue)
    		e.ClickedItem.BackColor = Color.Blue;
    }
