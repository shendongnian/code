	//check each column name for a change
	foreach (String columnName in columnNames)
	{
		//this grabs whatever value is in that field                            
		String origRowValue = "" + origRow.Field<Object>(columnName);
		String modRowValue = "" + modRow.Field<Object>(columnName);
		//check if they are the same
		if (origRowValue.Equals(modRowValue))
		{
			//if they aren the same, increase the number matched by one
			numberMatched++;
			//add the column to the list of columns that don't match
		}
		else
		{
			mismatchedColumns.Add(columnName);
		}
	}
