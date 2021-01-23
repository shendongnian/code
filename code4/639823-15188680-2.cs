    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.Sql.SqlConnection conn= new System.Data.Sql.SqlConnection(/*your connection string comes here*/);
        string query= "SELECT name, num  FROM Table WHERE T_Name=@MyString";
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.Sql.SqlCommand cmd = new System.Data.Sql.SqlCommand(query, conn);
        
        System.Data.Sql.SqlDataAdapter da1 = new System.Data.Sql.SqlDataAdapter(cmd );
        da1.SelectCommand.Parameters.AddWithValue("@MyString", your_string);
        
        da1.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
