    public static DataTable GetExcelData(string connectionString)
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
                    DataTable dtSchema = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
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
