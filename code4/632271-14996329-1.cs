    SqlConnection objConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["STERIAConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        var objCmd = new SqlCommand("SELECT * FROM DEPT", objConn);
        objConn.Open();
        GridView1.DataSource = objCmd.ExecuteReader();
        GridView1.DataBind();
        objConn.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var checkbox1 = e.Row.FindControl("CheckBox1") as CheckBox;
            checkbox1.Attributes.Add("OnClick","return ChangeBackgroundColor('checkbox1');");
        }
    }
