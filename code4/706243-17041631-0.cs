    public void MakeTable(string tableName, List<string> ids, SqlConnection connection)
    {
        SqlCommand cmd = new SqlCommand("CREATE TABLE ##" + tableName + " (ID int)", connection);
        cmd.ExecuteNonQuery();
        DataTable localTempTable = new DataTable(tableName);
        DataColumn id = new DataColumn();
        id.DataType = System.Type.GetType("System.Int32");
        id.ColumnName = "ID";
        localTempTable.Columns.Add(id);
        System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();        
        sw1.Start();
        foreach (var item in ids)
        {
            DataRow row = localTempTable.NewRow();
            row[0] = item;
            localTempTable.Rows.Add(row);
            
        }
        localTempTable.AcceptChanges();
        long temp1 = sw1.ElapsedMilliseconds;
        sw1.Reset();
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "##" + tableName;
            bulkCopy.WriteToServer(localTempTable);
        }
        long temp2 = sw1.ElapsedMilliseconds;
    }
