    protected void BindGridControl(int pageNumber = 0)
    { 
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings[connect‌​ion].ConnectionStrin‌​g);
        SqlDataReader dr;
        SqlCommand cmd;
        cmd = new SqlCommand();
        cmd.Connection = sqlConn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_load";
        sqlConn.Open();
        dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        GridView1.PageIndex = pageNumber;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        sqlConn.Close();
    }
