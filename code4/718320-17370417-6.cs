    protected void Page_Load(object sender, EventArgs e)
    {
    
       string dsn = "foo";
       string sql = @"GetProjectBudgetInfo";
       using (SqlConnection conn = new SqlConnection(dsn))
       using (SqlCommand cmd = new SqlCommand(sql, conn))
       {
           cmd.CommandType = CommandType.StoredProcedure;
           conn.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           testGrid.DataSource = reader;
           testGrid.DataBind();
       }
    }    
