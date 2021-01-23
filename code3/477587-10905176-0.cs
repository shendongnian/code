    internal override bool RecordExists(DataRow row)
    {
        string query = string.Concat("SELECT 1 FROM ", row.Table.TableName, " ", GetDbTableFilter(row, row.Table.PrimaryKey), " AND ROWNUM = 1");
        using(OracleCommand cmd = new OracleCommand(query, (OracleConnection)_connectionLibrary.CurrentConnection))
            using(OracleDataReader reader = cmd.ExecuteReader())
                return (reader != null && reader.Read());
    }
		
    internal override string GetDbTableFilter(DataRow row, DataColumn[] columns)
    {
        string filter = "";
        foreach (DataColumn column in columns)
        {
            if (!string.IsNullOrEmpty(filter))
                filter += " AND ";
            if (string.IsNullOrEmpty(row[column].ToString()))
            {
                filter += string.Concat("(", column.ColumnName, " IS NULL OR TRIM(", column.ColumnName, ") = '')");
                continue;
            }
            if (column.DataType.Equals(typeof(DateTime)))
            {
                filter += string.Concat(column.ColumnName, " = TO_DATE('", row[column].ToString(), "')");
                continue;
            }
            filter += string.Concat(column.ColumnName, " = '", row[column].ToString(), "'");
        }
        return string.Concat("WHERE ", filter);
    }
    public override void SaveDataTable(DataTable dataTable)
    {
        dataTable.AcceptChanges();
        foreach (DataRow row in dataTable.Rows)
            if(RecordExists(row))
                row.SetModified();
            else
                row.SetAdded();
        using (OracleDataAdapter adapter = new OracleDataAdapter(string.Format("SELECT * FROM {0}", dataTable.TableName), (OracleConnection)_connectionLibrary.CurrentConnection))
            using (OracleCommandBuilder commandBuilder = new OracleCommandBuilder(adapter))
            {
                commandBuilder.SetAllValues = true;
                commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                adapter.InsertCommand = commandBuilder.GetInsertCommand(true);
                adapter.UpdateCommand = commandBuilder.GetUpdateCommand(true);
                adapter.Update(dataTable);
            }
    }
