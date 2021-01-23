    private void dataGrid1_DoubleClick(object sender, EventArgs e)
    {
    	SourceGrid.DataGrid dg = (SourceGrid.DataGrid)sender;
    	//Get the position of the clicked cell
    	int c = dg.MouseCellPosition.Column;
    	int r = dg.MouseCellPosition.Row;
    	//create a Cell context 
    	SourceGrid.CellContext cc = new SourceGrid.CellContext(dg, new SourceGrid.Position(r,c));
    	//and retrieve the value to be compared with a pre-defined text
    	if (String.Compare(cc.DisplayText, "SOMETEXT") == 0)
    		this.dataGrid1.GetCell(r, c).Editor.EnableEdit = false; //Disable the editing 
    	else
    		this.dataGrid1.GetCell(r, c).Editor.EnableEdit = true;  //Enable the editing
    }
