    private void RetrieveColumnInfo(OleDbConnection cnn, TableSchema tableSchema,
              string[] restrictions, Func<string, string> prepareColumnNameForMapping)
    {
        using (DataTable dtColumns = 
                     cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions)) {
            string AutoNumberColumn = RetrieveAutoNumberColumn(cnn, tableSchema);
            foreach (DataRow row in dtColumns.Rows) {
                var col = new TableColumn();
                col.ColumnName = (string)row["COLUMN_NAME"];
                try {
                    col.ColumnNameForMapping =
                        prepareColumnNameForMapping(col.ColumnName);
                } catch (Exception ex) {
                    throw new UnimatrixExecutionException(
                        "Error in delegate 'prepareColumnNameForMapping'", ex);
                }
                col.ColumnAllowsDBNull = (bool)row["IS_NULLABLE"];
                col.ColumnIsIdentity = col.ColumnName == AutoNumberColumn;
                DbColumnFlags flags = (DbColumnFlags)(long)row["COLUMN_FLAGS"];
                col.ColumnIsReadOnly =
                    col.ColumnIsIdentity ||
                    (flags & (DbColumnFlags.Write | DbColumnFlags.WriteUnknown)) ==
                                                                   DbColumnFlags.None;
                if (row["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value) {
                    col.ColumnMaxLength = (int)(long)row["CHARACTER_MAXIMUM_LENGTH"];
                }
                col.ColumnDbType = GetColumnDbType((int)row["DATA_TYPE"]);
                col.ColumnOrdinalPosition = (int)(long)row["ORDINAL_POSITION"];
                GetColumnDefaultValue(row, col);
                tableSchema.ColumnSchema.Add(col);
            }
        }
    }
