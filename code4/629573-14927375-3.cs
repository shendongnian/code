    List<string> primaryKeyColumns = GetPrimaryKeyColumns(SelectedDB, SelectedTable);
    string deleteWhereClause = string.Empty;
    foreach (string column in primaryKeyColumns)
    {
    	DataGridViewRow row = datagridview.CurrentCell.OwningRow;
    	string value = row.Cells[column].Value.ToString();
    
    	if (string.IsNullOrEmpty(deleteWhereClause))
    	{
    		deleteWhereClause = string.Concat(column, "=", value);
    	}
    	else 
    	{
    
    		deleteWhereClause += string.Concat(" AND ", column, "=", value);
    	}
    }
    string deleteStatement = string.Format("DELETE FROM {0} WHERE {1}", SelectedTable, deleteWhereClause);
