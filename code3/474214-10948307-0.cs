    public static void RemoveAndCreateLocalDb(string strLocalDbLocation)
        {
            try
            {
                if (File.Exists(strLocalDbLocation))
                {
                    File.Delete(strLocalDbLocation);
                }
                SqlCeEngine sceEngine = new SqlCeEngine(@"Data Source= " + strLocalDbLocation + ";Persist Security Info=True;Password=MyPass");
                sceEngine.CreateDatabase();
            }
            catch
            { }
        }
    public static void UpdateLocalDatabase(String strTableName, DataTable dttTable)
        {
            try
            {
                // Opening the Connection
                sceConnection = CreateDatabaseSQLCEConnection();
                sceConnection.Open();
                // Creating tables in sdf file - checking headers and types and adding them to a query
                StringBuilder stbSqlGetHeaders = new StringBuilder();
                stbSqlGetHeaders.Append("create table " + strTableName + " (");
                int z = 0;
                foreach (DataColumn col in dttTable.Columns)
                {
                    if (z != 0) stbSqlGetHeaders.Append(", "); ;
                    String strName = col.ColumnName;
                    String strType = col.DataType.ToString();
                    if (strType.Equals("")) throw new ArgumentException("DataType Empty");
                    if (strType.Equals("System.Int32")) strType = "int";
                    if (strType.Equals("System.String")) strType = "nvarchar (100)";
                    if (strType.Equals("System.Boolean")) strType = "nvarchar (15)";
                    if (strType.Equals("System.DateTime")) strType = "datetime";
                    if (strType.Equals("System.Byte[]")) strType = "nvarchar (100)";
                    stbSqlGetHeaders.Append(strName + " " + strType);
                    z++;
                }
                stbSqlGetHeaders.Append(" )");
                SqlCeCommand sceCreateTableCommand;
                string strCreateTableQuery = stbSqlGetHeaders.ToString();
                sceCreateTableCommand = new SqlCeCommand(strCreateTableQuery, sceConnection);
                sceCreateTableCommand.ExecuteNonQuery();
                
                StringBuilder stbSqlQuery = new StringBuilder();
                StringBuilder stbFields = new StringBuilder();
                StringBuilder stbParameters = new StringBuilder();
                stbSqlQuery.Append("insert into " + strTableName + " (");
                foreach (DataColumn col in dttTable.Columns)
                {
                    stbFields.Append(col.ColumnName);
                    stbParameters.Append("@" + col.ColumnName.ToLower());
                    if (col.ColumnName != dttTable.Columns[dttTable.Columns.Count - 1].ColumnName)
                    {
                        stbFields.Append(", ");
                        stbParameters.Append(", ");
                    }
                }
                stbSqlQuery.Append(stbFields.ToString() + ") ");
                stbSqlQuery.Append("values (");
                stbSqlQuery.Append(stbParameters.ToString() + ") ");
                
                string strTotalRows = dttTable.Rows.Count.ToString();
                foreach (DataRow row in dttTable.Rows)
                {
                    SqlCeCommand sceInsertCommand = new SqlCeCommand(stbSqlQuery.ToString(), sceConnection);
                    foreach (DataColumn col in dttTable.Columns)
                    {
                        if (col.ColumnName.ToLower() == "ssma_timestamp")
                        {
                            sceInsertCommand.Parameters.AddWithValue("@" + col.ColumnName.ToLower(), "");
                        }
                        else
                        {
                            sceInsertCommand.Parameters.AddWithValue("@" + col.ColumnName.ToLower(), row[col.ColumnName]);
                        }
                    }
                    sceInsertCommand.ExecuteNonQuery();
                }
            }
            catch { }
        }
