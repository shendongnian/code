    protected void ddlNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNumber = FVStudentClass.FindControl("ddlNumber") as DropDownList;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ReinstatementCS"].ConnectionString);
        SqlCommand myCommand = new SqlCommand("SELECT DISTINCT ClassSection FROM Classes WHERE Number = " + ddlNumber.Text);
        myCommand.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(myCommand);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DropDownList ddlSection = FVStudentClass.FindControl("ddlSection") as DropDownList;
        ddlSection.DataSource = dt;
        ddlSection.DataTextField = "ClassSection";
        ddlSection.DataValueField = "ClassSection";
        ddlSection.DataBind();
        ddlSection.Items.Insert(0, "--Select--");
    }
