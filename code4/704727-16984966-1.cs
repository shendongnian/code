    protected override void PageLoad(object sender, System.EventArgs e)
    {
                
        if (!IsPostBack)
        {
                
            GridView1.DataSource = getDataSource();
            GridView1.DataBind();
    
        }
    }
    private DataTable getDataSource()
    {
                
        SqlConnection conn = new SqlConnection("Server=192.168.1.1;DATABASE=dummy;UID=****;PWD=*****;");    //Example connString
        SqlCommand comm = new SqlCommand("SELECT * FROM Table1", conn);
        SqlDataAdapter ad = new SqlDataAdapter(comm);
    
        DataTable ta = new DataTable();
        ad.Fill(ta);
    
        return ta;
    }
    
    protected void button_click(object sender, EventArgs e)
    {
        LinkButton asd = (LinkButton)sender;
        GridViewRow row = (GridViewRow)asd.NamingContainer;     //Gets the selected Row
    
        string user_id = row.Cells[2].Text;     //Use this to get any value you want.
        //Can now use the user_name to get the data for the grid 2, and update the panel
        GridView2.DataSource = getDataSource2(user_id);
        GridView2.DataBind();
        UpdatePanel1.Update();
    }
    private DataTable getDataSource2(string user_id)
    {
        string sql = "SELECT * FROM TABLE2 WHERE user_id = @user_id";
        SqlConnection conn = new SqlConnection("Server=sqlserver\\sql2008;DATABASE=esm80;UID=sa;PWD=sa;");    //Example connString
        SqlCommand comm = new SqlCommand();
        comm.CommandText = sql;
        comm.Parameters.AddWithValue("@name", user_id);
        comm.Connection = conn;
    
        SqlDataAdapter ad = new SqlDataAdapter(comm);
    
        DataTable ta = new DataTable();
        ad.Fill(ta);
    
        return ta;
    }
