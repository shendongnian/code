	private void list_MouseDown(object sender, MouseEventArgs e)
	{
		if ( e.Clicks >= 2 )
			list_MouseDoubleClick(sender, e);
	}
