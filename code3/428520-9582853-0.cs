	DataGridViewColumn  newCol = new DataGridViewColumn(); // add a column to the grid
	DataGridViewCell cell = new DataGridViewCell(); //Specify which type of cell in this column
	newCol.CellTemplate = cell;
	 
	newCol.HeaderText = "test2";
	newCol.Name = "test2";
	newCol.Visible = true;
	newCol.Width = 40;
	 
	gridColors.Columns.Add(newCol);
