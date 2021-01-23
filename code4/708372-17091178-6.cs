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
	//...
