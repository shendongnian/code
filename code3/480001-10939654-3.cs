    int loRow = dgvC.SelectedCells.Cast<DataGridViewCell>().Select(c => c.RowIndex).Min();
    int hiRow = dgvC.SelectedCells.Cast<DataGridViewCell>().Select(c => c.RowIndex).Max();
    
    int loCol = dgvC.SelectedCells.Cast<DataGridViewCell>().Select(c => c.ColumnIndex).Min();
    int hiCol = dgvC.SelectedCells.Cast<DataGridViewCell>().Select(c => c.ColumnIndex).Max();
    
    for (int i = loRow; i <= hiRow; i++)
    {
    	// start with rightmost row
    	int curCopyCol = hiCol;
    
    	// now copy to dgvC, starting with hiCol + 1
    	for (int j = hiCol + 1; j < dgvC.Columns.Count; j++)
    	{
    		dgvC.Rows[i].Cells[j].Value = dgvC.Rows[i].Cells[curCopyCol--].Value;
    
    		if (curCopyCol < loCol)
    			curCopyCol = hiCol;
    	}
    
    	// finally, continue copying in dgvN
    	for (int j = 1; j < dgvN.Columns.Count; j++)
    	{
    		dgvN.Rows[i].Cells[j].Value = dgvC.Rows[i].Cells[curCopyCol--].Value;
    
    		if (curCopyCol < loCol)
    			curCopyCol = hiCol;
    	}
    }
