    public static DataTable GetExcelData(string connectionString, DatabaseTypes connectionTypeSQL = DatabaseTypes.SQLServer)
    {
        string sql = string.Empty;
        using (OleDbConnection cn = new OleDbConnection(connectionString))
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter())
            {
                DataTable dt = new DataTable();
                using (OleDbCommand command = cn.CreateCommand())
                {
                    cn.Open();
                    DataTable dtSchema =  GetDatabaseTables(connectionString,"", connectionTypeSQL);
                    string firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                    sql = "SELECT * FROM [" + firstSheetName + "]";
                    command.CommandText = sql;
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        OleDbDataReader reader = command.ExecuteReader();
                        dt.Load(reader);
                    }
                    cn.Close();
                    return dt;
                }
            }
        }
    }
    public static DataTable GetDatabaseTables(string connectionString, string databaseName = "", DatabaseTypes connectionTypeSQL = DatabaseTypes.SQLServer)
    {
        DataTable dt = new DataTable();
        //string[] restrictions = new string[4] { databaseName, null, null, null };
        string[] restrictions = new string[4] { databaseName, null, null, "Table" };
        try
        {
            switch (connectionTypeSQL)
            {
                case DatabaseTypes.SQLServer:
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        if (databaseName != "")
                        {
                            dt = conn.GetSchema("Tables", restrictions);
                        }
                        else
                        {
                            dt = conn.GetSchema("Tables");
                        }
                        return dt;
                    }
                    break;
                case DatabaseTypes.OLEDB:
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        if (databaseName != "")
                        {
                            dt = conn.GetSchema("Tables", restrictions);
                        }
                        else
                        {
                            dt = conn.GetSchema("Tables");
                        }
                        return dt;
                    }
                    break;
                case DatabaseTypes.MySQL:
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        if (databaseName != "")
                        {
                            dt = conn.GetSchema("Tables", restrictions);
                        }
                        else
                        {
                            dt = conn.GetSchema("Tables");
                        }
                        return dt;
                    }
                    break;
                default:
                    return dt;
                    break;
            }
        }
        catch (Exception ex)
        {
            //Logging.clsLog(string.Format("{0} ({1})", ex.Message, ex.InnerException));
            //MessageBox.Show(ex.Message, GlobalVar.Error);
            return dt;
        }
    }
    public enum DatabaseTypes
    {
        SQLServer,
        OLEDB,
        MySQL
    }
