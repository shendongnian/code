    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string searchBoxValue = SearchBox.Text;
        string columnNameValue = ColumnName.SelectedValue;
        columnNameValue.ToLower();
        string sqlQuery = "select * from registrants";
        DataTable dt = new DataTable();
        
        using (SqlCommand searchCommand = new SqlCommand(sqlQuery, connection))
        {
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                  dt.Load(reader);
            }
        }
        RegistrantsView.DataSource = dt;
        RegistrantsView.DataBind();
    }
