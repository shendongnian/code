    //Get a range object that contains the cell.
	Parameters = new Object[2];
	Parameters[0] = iRow + 1;
	Parameters[1] = iCol;
	objRange_Late = objSheet_Late.GetType().InvokeMember( "Cells",
		BindingFlags.GetProperty, null, objSheet_Late, Parameters );
	//Write value in cell
	Parameters = new Object[1];
	Parameters[0] = row[col.ColumnName];
	objRange_Late.GetType().InvokeMember( "Value", BindingFlags.SetProperty, 
		null, objRange_Late, Parameters );
