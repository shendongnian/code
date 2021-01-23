     public bool BulkInsertDataTable(string tableName, DataTable dataTable, string[] commonColumns)
        {
            bool isSuccuss;
            try
            {
                SqlConnection SqlConnectionObj = GetSQLConnection();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(SqlConnectionObj, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.ColumnMappings.Clear();
                for (int iDtColumnCount = 0; iDtColumnCount < dataTable.Columns.Count; iDtColumnCount++)
                {
                    for (int iArrCount = 0; iArrCount < commonColumns.Length; iArrCount++)
                    {
                        if (dataTable.Columns[iDtColumnCount].ColumnName.ToString().Equals(commonColumns[iArrCount].ToString()))
                        {
                            bulkCopy.ColumnMappings.Add(dataTable.Columns[iDtColumnCount].ColumnName.ToString(),
                                                        commonColumns[iArrCount].ToString());
                        }
                    }
                }
                
                bulkCopy.WriteToServer(dataTable);
                isSuccuss = true;
            }
            catch (Exception ex)
            {
                isSuccuss = false;
            }
            return isSuccuss;
        }
