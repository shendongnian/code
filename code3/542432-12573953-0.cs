    private void dataGridViewPlatypi_CellEnter(object sender, 	DataGridViewCellEventArgs args)
    {
    	string prevVal = string.Empty;
    	if (args.RowIndex > 0)
    	{
    		prevVal = dataGridViewPlatypi.Rows[args.RowIndex - 1].Cells[args.ColumnIndex].Value.ToString();
    	} else if (args.ColumnIndex > 1)
    	{
    		prevVal = dataGridViewPlatypi.Rows[args.RowIndex].Cells[args.ColumnIndex-1].Value.ToString();
    	}
    	dataGridViewPlatypi.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = prevVal;
    }
