    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        SqlConnection conn= new SqlConnection(/*your connection string comes here*/);
        string query= "SELECT name, num  FROM Table WHERE T_Name=@MyString";
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(query, conn);
        
        SqlDataAdapter da1 = new SqlDataAdapter(cmd );
        da1.SelectCommand.Parameters.AddWithValue("@MyString", your_string);
        
        da1.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
