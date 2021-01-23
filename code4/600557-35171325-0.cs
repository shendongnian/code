    public void AutoUpdateColumnWidth(ListView lv)
    {
    	for (int i = 0; i <= lv.Columns.Count - 1; i++) {
    		lv.Columns(i).Width = -2;
    	}
    }
