        private void AssignMandatoryColumns([NotNull] DataTable structure, string tableName)
        {
            // find schema
            string[] restrictions = new string[4]; // Catalog, Owner, Table, Column
            restrictions[2] = tableName;
            DataTable schemaTable = _dbCon.GetSchema("Columns", restrictions);
            if (schemaTable == null) return;
            // set values for columns
            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                if (!structure.Columns.Contains(columnName)) continue;
                if (row["IS_NULLABLE"].ToString() == "NO") structure.Columns[columnName].AllowDBNull = false;
                //if (structure.Columns[columnName].AutoIncrement) continue; // there can be no default value
                var valueType = row["DATA_TYPE"];
                var defaultValue = row["COLUMN_DEFAULT"];
                try
                {
                    structure.Columns[columnName].DefaultValue = defaultValue;
                    if (!structure.Columns[columnName].AllowDBNull && structure.Columns[columnName].DefaultValue is DBNull)
                    {
                        Logger.DebugLog("Database column {0} is not allowed to be null, yet there is no default value.", columnName);
                    }
                }
                catch (Exception exception)
                {
                    if (structure.Columns[columnName].AllowDBNull) continue; // defaultvalue is irrelevant since value is allowed to be null
                    Logger.LogWithoutTrace(exception, string.Format("Setting DefaultValue for {0} of type {1} {4} to {2} ({3}).", columnName, valueType, defaultValue, defaultValue.GetType(), structure.Columns[columnName].AllowDBNull ? "NULL" : "NOT NULL"));
                }
            }
        }
