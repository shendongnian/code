    public void clickit(Object sender, EventArgs e)
    {
        //call the function
        this.bindGrid();
    }
     //function to populate the datagrid with the data from the datasource
       private void bindGrid()
       {
        string sql = "SELECT a from table1";
        SqlConnection connection = new SqlConnection(connectionstring);
        SqlDataAdapter adap= new SqlDataAdapter(sql, connection);
        DataTable table = new DataTable();
        connection.Open();
        adap.Fill(table); //page reloads here, but hangs
        mygrid.DataSource = table;
        //bind the control with the data in the datasource
        mygrid.DataBind();
       connection.Close();
       }
