	private DataGridView grid
	private CacheAll memoryCache;
    private DataRetrieverAll retriever;
		
	public GUIHelper(DataGridView grid, GUI gui)
	{
		this.gui = gui;
		this.grid = grid;
		init();
	}
	
	private void init()
	{
		//...
	}
	
	public void getData(string selectCommand, string sortColumn, Boolean asc_all)
	{
		grid.VirtualMode = true;
		try
		{
			if (asc_all) sortColumn = "["+sortColumn + "] ASC"; else sortColumn = "["+sortColumn + "] DESC";
			
			retriever = new DataRetrieverAll("Insert ConnectionString here...", selectCommand, sortColumn);
			memoryCache = new CacheAll(retriever, GUI.amountDatasets); //amountDatasets = Amount of Datasets per cached-page
			
			if (grid.Columns.Count == 0)
			{
				foreach (DataColumn column in retriever.Columns)
				{
					grid.Columns.Add(column.ColumnName, column.ColumnName);
				}
			}
			grid.Rows.Clear();
			grid.RowCount = retriever.RowCount;
			grid.Refresh();
		}
		catch (SqlException)
		{
			MessageBox.Show("Connection could not be established. " +
				"Verify that the connection string is valid.");
			Application.Exit();
		}
	}
	
