    private void BindData()
    {
      SqlConnection myConnection = new SqlConnection(ConnectionString);
      SqlDataAdapter ad = new SqlDataAdapter(QUERY_SELECT_ALL_CATEGORIES,
      myConnection);
      DataSet ds = new DataSet();
      ad.Fill(ds, "Categories");
      GridView1.DataSource = ds;
      GridView1.DataBind();
    }
