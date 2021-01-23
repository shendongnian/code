    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
    	if ( e.Location.Y > headerHeightDefinedEarlier )
    		contextMenuStrip1.Show(listView1, e.Location);
    }
