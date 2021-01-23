    using (DataSet ds = new DataSet())
    {
        DataTable dt = new DataTable();
        ds.Tables.Add(dt);
        string str = "User ID=username;Password=password;Data Source=Test";
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "select * from table_name";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd); 
        da.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
