    public DataTable DBGetDataTable(string SQLQuery)
    {
        string MethodName = "public DataTable DBGetDataTable(string SQLQuery)";
        DataTable Result = null;
        SqlConnection SqlConnection = null;
        SqlCommand SqlCommand = null;
        try
        {
            string DatabaseName = "";
            string ServerNameOrIP = "";
            string DatabaseUserID = "";
            string Password = "";
            string ConnectionString = "database=" + DatabaseName + ";server=" + ServerNameOrIP + ";user ID=" + DatabaseUserID + ";PWD=" + Password + ";Connection Timeout=5000";
            SqlConnection = new SqlConnection(ConnectionString);
           
            SqlCommand = new SqlCommand(SQLQuery, SqlConnection);
            SqlConnection.Open();
            SqlDataReader SqlDataReader = SqlCommand.ExecuteReader();
            if (SqlDataReader.HasRows)
            {
                DataTable Dt = new DataTable();
                Dt.Load(SqlDataReader);
                Result = Dt;
            }
        }
        catch (Exception ex)
        {
            //Common.Exception(ClassName, MethodName, ex);
        }
        finally
        {
            SqlConnection.Close();
            SqlConnection.Dispose();
            SqlConnection = null;
            SqlCommand.Dispose();
            SqlCommand = null;
        }
        return Result;
    }
