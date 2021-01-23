    class MyDataGridView : DataGridView
    {
    	public MyDataGridView()
    	{
    		base.DataBindingComplete += Sort;
    	}
    
    	public void Sort(object sender, EventArgs e)
    	{
    		Sort(Columns[0], ListSortDirection.Ascending);
    		Columns[0].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
    	}
    }
