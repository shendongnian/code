    public DataTable fillDataTable(string table)
    {
        string query = "SELECT * FROM dstut.dbo.[" + table + "]";
        using(SqlConnection sqlConn = new SqlConnection(conSTR))
        using(SqlCommand cmd = new SqlCommand(query, sqlConn))
        {
            sqlConn.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
