    public static DataTable GetDataTable(string sConnStr, string sTable)
    {
        using (SqlConnection sqlConn10 = new SqlConnection(sConnStr))
        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM EmployeeIDs", sqlConn10))
        {
            sqlConn10.Open();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
