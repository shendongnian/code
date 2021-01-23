    protected void Page_Load(object sender, EventArgs e)
    {
         Page.Title = title();
    }
    private string title()
    {
        SqlConnection con = new SqlConnection(cs);
        string cmdstr = "select * from title where id = 2";
        SqlCommand cmd = new SqlCommand(cmdstr, con);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
            string title = dt.Rows[0]["title"].ToString();
        }
        return title;
    }
