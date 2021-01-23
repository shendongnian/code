    SqlDataSource searchResults = new SqlDataSource(WebConfigurationManager.ConnectionStrings["MyDbConn"].ToString(), "SELECT * FROM Books WHERE id=1");
    searchResults.ID = "searchResults"; //or something else
    this.Controls.Add(searchResults);
    GridView1.DataSourceID = searchResults.ID;
    GridView1.DataBind();
