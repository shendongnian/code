    private static void DataReaderBulkCopySample()
    {            
        using (var reader = new ExcelDataReader(@"test.xlsx"))
        {
            var cols = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();
            DataHelper.CreateTableIfNotExists(ConnectionString, TableName, cols);
            using (var bulkCopy = new SqlBulkCopy(ConnectionString))
            {
                // MSDN: When EnableStreaming is true, SqlBulkCopy reads from an IDataReader object using SequentialAccess, 
                // optimizing memory usage by using the IDataReader streaming capabilities
                bulkCopy.EnableStreaming = true;
                bulkCopy.DestinationTableName = TableName;
                foreach (var col in cols)
                    bulkCopy.ColumnMappings.Add(col, col);
                bulkCopy.WriteToServer(reader);
            }
        }
    }
