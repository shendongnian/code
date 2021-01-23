    public DataTable ReadTable(string sql, params object[] parameters) {
        
        using (var cmd = CreateCommand(sql, parameters))
			{
				var reader = cmd.ExecuteReader();
				if (reader == null)
				{
					return null;
				}
    
				var schemaTable = reader.GetSchemaTable();
                                DataTable dt = GetTable(schemaTable);
				while (reader.Read())
				{
					var values = new object[reader.FieldCount];
					reader.GetValues(values);
                                        dt.Rows.Add(values);
				
				}
			}
    }
    private DataTable GetTable(DataTable schemaTable) {
			if (schemaTable == null || schemaTable.Rows.Count == 0)
			{
				return null;
			}
			var dt = new DataTable();
			foreach (DataRow schemaRow in schemaTable.Rows)
			{
				var col = new DataColumn
				{
					ColumnName = schemaRow["ColumnName"].ToString(),
                                        DataType = schemaRow["DataType"]
                                      // use the debugger to find out the name of the type column in the schematable, 
                                      // and any other properties you need
				};
                                dt.Columns.Add(col);
			}
			return dt;
    }
