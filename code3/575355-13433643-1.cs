    public static string GetOneFieldRecord(string field, string companyNum)
    {
        DataSet ds = new DataSet();
        SqlCommand comm = new SqlCommand();
        string strSQL = string.Format("SELECT {0} FROM Companies WHERE CompanyNum = @CompanyNum", field);
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = @connstring;
        comm.Connection = conn;
        comm.CommandText = strSQL;
        comm.Parameters.AddWithValue("@FieldName", field);
        comm.Parameters.AddWithValue("@CompanyNum", companyNum);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = comm;
        conn.Open();
        da.Fill(ds, "CompanyInfo");
       conn.Close();
       return ds.Tables[0].Rows[0].ItemArray[0].ToString();
    }
