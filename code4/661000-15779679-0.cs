    public bool BulkInsertDataTable(string tableName, DataTable dataTable)
    {
        bool isSuccuss;
        try
        {
            SqlConnection SqlConnectionObj = GetSQLConnection();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionObj, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.WriteToServer(dataTable);
            isSuccuss = true;
        }
        catch (Exception ex)
        {
            isSuccuss = false;
        }
        return isSuccuss;
    }
