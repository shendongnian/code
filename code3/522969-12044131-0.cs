    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlDemo.DataSource = new string[] { "asdf", "jklö" };
            ddlDemo.DataBind();
        }
    }
    protected void btnDemo_Click(object sender, EventArgs e)
    {
        Debug.WriteLine(ddlDemo.Text);
        SqlConnection con = null;
        using (con = new SqlConnection("YOUR CON STRING"))
        {
            SqlCommand com = new SqlCommand( "update tblXYZ set ABC = @A", con);
            SqlParameter param = new SqlParameter("A", System.Data.SqlDbType.YOURTYPE);
            param.Value = ddlDemo.Text;
            com.Parameters.Add(param);
            con.Open();
            int affectedRows = com.ExecuteNonQuery();
            Debug.WriteLine(affectedRows + " affected!");
            con.Close();
        }
    }
