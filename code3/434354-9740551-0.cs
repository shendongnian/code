    private string RetrieveAutoNumberColumn(OleDbConnection cnn, TableSchema tableSchema)
    {
        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + tableSchema.TableName + "] WHERE False", cnn);
        DataTable dtSchema = adapter.FillSchema(new DataTable(), SchemaType.Source);
        if (dtSchema == null) {
            throw new UnimatrixMappingException("Table \"" + tableSchema.TableName + "\" not found. Connection = " + this._connectString);
        }
        string columnName = null;
        for (int i = 0; i < dtSchema.Columns.Count; i++) {
            if (dtSchema.Columns[i].AutoIncrement) {
                columnName = dtSchema.Columns[i].ColumnName;
                break;
            }
        }
        return columnName;
    }
