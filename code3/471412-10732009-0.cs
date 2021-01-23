    protected void Page_Load(object sender, EventArgs e)
        {
           GridBindData(); // on page load 
        }
    public void GridBindData()
        {
            MySqlConnection Conn; // I am using MySql 
            myConn = new MySqlConnection("server=localhost;user=root;database=DBName;");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select Name, address, mobileNo, emailID from  user", conn);
             MySqlDataReader reader = cmd.ExecuteReader();
            // As DataReader can move only in forward it is not useful to use it GridView.
           // So convert it to DataTable(or?). It can move in both direction
            DataTable dTable = new DataTable();
            dTable.Load(reader); // ASP function to convert reader to DataTable
             
            RestGridData.DataSource = dTable; 
            RestGridData.DataBind();
             
        }
    protected void RestGridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RestGridData.PageIndex = e.NewPageIndex;
            GridBindData();
        }
