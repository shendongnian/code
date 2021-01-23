    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
                string EmployeeID = GridView1.DataKeys[e.RowIndex].Value.ToString();
                string Query = “delete Employee where Employee.EmployeeID = “ + EmployeeID;
                BindGridData(Query);
         }
    private void BindGridData(string Query)
    {
      string connectionstring  =        ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString;
     
      using (SqlConnection conn = new SqlConnection(connectionstring))
      {
        conn.Open();
        using (SqlCommand comm = new SqlCommand(Query, conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
      }
