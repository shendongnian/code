    private SqlConnection Conn;
     private void CreateConnection()
     {
        string ConnStr =
        ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        Conn = new SqlConnection(ConnStr);
     }
     public DataTable getData()
     {
     CreateConnection();
        string SqlString = "SELECT * FROM TableName WHERE SomeID = @SomeID;";
        SqlDataAdapter sda = new SqlDataAdapter(SqlString, Conn);
        DataTable dt = new DataTable();
        try
        {
        	Conn.Open();
            sda.Fill(dt);
        }
        catch (SqlException se)
        {
            DBErLog.DbServLog(se, se.ToString());
        }
        finally
        {
            Conn.Close();
        }
        return dt;
    }
