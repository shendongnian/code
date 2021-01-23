    protected void bind()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Your Query", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        gvCourse.DataSource = ds;
        gvCourse.DataBind();
        con.Close();
    }
