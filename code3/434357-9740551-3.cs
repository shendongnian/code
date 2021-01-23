    private static void RetrievePrimaryKeyInfo(OleDbConnection cnn, TableSchema tableSchema, string[] restrictions)
    {
        using (DataTable dtPrimaryKeys = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, restrictions)) {
            foreach (DataRow row in dtPrimaryKeys.Rows) {
                string columnName = (string)row["COLUMN_NAME"];
                //TODO:  Do something useful with columnName here
            }
        }
    }
