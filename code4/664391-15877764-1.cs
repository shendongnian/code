    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        LoadData();
      }
    }
    
    private void LoadData()
    {
      string constr = @"Server=.\SQLEXPRESS;Database=TestDB;uid=waqas;pwd=sql;";
      string query = @"SELECT CategoryID, CategoryName, Approved FROM Categories";
    
      SqlDataAdapter da = new SqlDataAdapter(query, constr);
      DataTable table = new DataTable();
      da.Fill(table);
    
      GridView1.DataSource = table;
      GridView1.DataBind();
    }
    
    public void chkStatus_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkStatus = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
    
       
        string cid = row.Cells[1].Text;
        bool status = chkStatus.Checked;
    
       
        string constr = @"Server=.\SQLEXPRESS;Database=TestDB;uid=waqas;pwd=sql;";
        string query = "UPDATE Categories SET Approved = @Approved WHERE CategoryID = @CategoryID";
           
        SqlConnection con = new SqlConnection(constr);
        SqlCommand com = new SqlCommand(query, con);
    
       
        com.Parameters.Add("@Approved", SqlDbType.Bit).Value = status;
        com.Parameters.Add("@CategoryID", SqlDbType.Int).Value = cid;
    
       
        con.Open();
        com.ExecuteNonQuery();
        con.Close();
       
        LoadData();
    } 
