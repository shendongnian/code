    CopyDataFromOneToOther(DB2, myDataTable, "tableName");
    private static void CopyDataFromOneToOther(String sConnStr, DataTable dt, String sTableName)
    {
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sConnStr, SqlBulkCopyOptions.TableLock)) {
    	bulkCopy.DestinationTableName = sTableName;
    	bulkCopy.WriteToServer(dt);
        }                    
    }
