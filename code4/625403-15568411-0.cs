    public DataSet sMethod()
    {
        using (SqlConnection cnn = new SqlConnection(DBcon))
        {
            string sql = "SELECT * FROM table";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            return ds;
        }
    }
