    public void Copy(String tableName, DataTable dataTable)
    {
        var insert = $"insert into {tableName} ({GetColumnNames(dataTable)}) values ({GetParamPlaceholders(dataTable)})";
        using (var connection = /*a method to get a new open connection*/)
        {       
            for (var row = 0; row < dataTable.Rows.Count; row++)
            {
                InsertRow(dataTable, insert, connection, row);
            }
        }
    }
    
    private static void InsertRow(DataTable dataTable, String insert, OracleConnection connection, Int32 row)
    {
        using (var command = new OracleCommand(insert, connection))
        {
            AssembleParameters(dataTable, command, row);
            command.ExecuteNonQuery();
        }
    }
    
    private static void AssembleParameters(DataTable dataTable, OracleCommand command, Int32 row)
    {
        for (var col = 0; col < dataTable.Columns.Count; col++)
        {
            command.Parameters.Add(ParameterFor(dataTable, row, col));
        }
    }
    
    private static OracleParameter ParameterFor(DataTable dataTable, Int32 row, Int32 col)
    {
        return new OracleParameter(GetParamName(dataTable.Columns[col]), dataTable.Rows[row].ItemArray.GetValue(col));
    }
    
    private static String GetColumnNames(DataTable data) => (from DataColumn column in data.Columns select column.ColumnName).StringJoin(", ");
    
    private static String GetParamPlaceholders(DataTable data) => (from DataColumn column in data.Columns select GetParamName(column)).StringJoin(", ");
    
    private static String GetParamName(DataColumn column) => $":{column.ColumnName}_param";
