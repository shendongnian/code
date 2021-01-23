    private Dictionary<string, string> GetComboData(string table, int column, bool id, int idField = 0)
    {
    	SqlClass sql = new SqlClass(database);
    	Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
    
    	if (sql.connectedToServer)
    	{
    		sql.SelectResults(SQLCommands.Commands.SelectAll(table));
    
    		for (int i = sql.table.Rows.Count-1; i >= 0; i--)
    		{
    			string tool = sql.table.Rows[i].ItemArray.Select(x => x.ToString()).ToArray()[column];
    			string ID = sql.table.Rows[i].ItemArray.Select(x => x.ToString()).ToArray()[idField];
    
    			comboBoxData.Add(ID, tool);
    		}
    
    	}
    
    	return comboBoxData;
    }
