    ...Windows.Forms designer code...
    listView.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.listView_DrawColumnHeader);
    ...
	private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
	{
		e.DrawDefault = true;
	}
