	//...
	private String columnToSortByAll;
	
	public GUI()
	{
		InitializeComponent();
		init();
	}
	private void init()
	{
		helper = new GUIHelper(grid, this);
		
		//Tabellen mit Werten füllen
		fillTablesInit();
	}
	
	private void fillTablesInit()
	{
		helper.getData("(SELECT * FROM TOOL_materialSumme WHERE Display IS NULL OR Display = 1)a", "ID", asc_all); //asc_all = Boolean value, indicating sort direction asc /desc
	}
	
	private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		String columnName = grid.Columns[e.ColumnIndex].Name;
		if (columnName.Equals(columnToSortBy))
		{
			if (asc_all) asc_all = false; else asc_all = true;
		}
		else
		{
			columnToSortBy = columnName;
			asc_all = true;
		}
		helper.getDataALL("(SELECT * FROM TOOL_materialSumme WHERE Display IS NULL OR Display = 1)a", columnToSortBy, asc_all);
	}
	
	private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		String actualValue = helper.getMemoryCache().RetrieveElement(e.RowIndex, e.ColumnIndex);
		e.Value = actualValue;
	}
	private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		//MessageBox.Show(e.Context.ToString());
	}
	private void grid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
	{
		String newValue = "";
		if (e.Value != null) newValue = e.Value.ToString();
		 
		int column = e.ColumnIndex;
		ASC.Code.Forms.Helper.CacheAll.DataPage[] pages = helper.getMemoryCache().getCachePages();
		DataTable[] tables = new DataTable[2];
		SqlDataAdapter[] adapters = new SqlDataAdapter[2];
		tables[0] = pages[0].getTable();
		tables[1] = pages[1].getTable();
		adapters[0] = pages[0].getAdapter();
		adapters[1] = pages[1].getAdapter();
		String id = grid.Rows[e.RowIndex].Cells["ID"].Value.ToString();
		for (int x = 0; x < tables.Length; x++)
		{
			for (int a = 0; a < tables[x].Rows.Count; a++)
			{
				String temp = tables[x].Rows[a][column].ToString();
				if (tables[x].Rows[a]["ID"].ToString() == id)
				{
					tables[x].Rows[a][column] = newValue;
					adapters[x].Update(tables[x]);
					break;
				}
			}
		}
		grid.Refresh();
	}
	//...
