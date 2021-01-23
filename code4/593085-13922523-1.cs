    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string searchBoxValue = SearchBox.Text;
        string columnNameValue = ColumnName.SelectedValue;
        columnNameValue.ToLower();
        SqlCommand searchCommand = new SqlCommand();
        searchCommand.Connection = connection;
         // Change this line - USE A PARAMERTIZED QUERY!!
        string searchQuery = "select * from registrants where "+columnNameValue+" = '"+searchBoxValue+"'";
        searchCommand.CommandText = searchQuery;
        SqlDataAdapter sda = new SqlDataAdapter(searchCommand);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        RegistrantsView.DataSource = dt;
        RegistrantsView.DataBind();
    }
