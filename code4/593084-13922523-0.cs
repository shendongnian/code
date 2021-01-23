    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string searchBoxValue = SearchBox.Text;
        string columnNameValue = ColumnName.SelectedValue;
        columnNameValue.ToLower();
        SqlCommand searchCommand = new SqlCommand();
        searchCommand.Connection = connection;
        string searchQuery = // USE A PARAMERTIZED QUERY!!
        searchCommand.CommandText = searchQuery;
        SqlDataAdapter sda = new SqlDataAdapter(searchCommand);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        RegistrantsView.DataSource = dt;
        RegistrantsView.DataBind();
    }
