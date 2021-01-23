    static SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["Connection"].ToString());
    [WebMethod]
    public DataSet Cmb_BranchMaster()
    {
        conn.Open();
        SqlCommand ad1 = new SqlCommand("select * from BranchMaster", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(ad1);
        DataSet ds = new DataSet();
        adapt.Fill(ds);
        conn.Close();
        return ds;
    }
