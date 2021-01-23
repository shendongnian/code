    if (isPostback)
    {
      FillGrid();    
    } 
    
    private void FillGrid()
    {
    
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select ID, Name, Address from dbo.MyTable", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
    }
 
