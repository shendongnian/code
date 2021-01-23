    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        string select = "select * from courses";
        DropDownList1.Items.Add("-- Select Course --");
        DropDownList1.SelectedIndex = 0;
        DataTable dt = con.select_command(select);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DropDownList1.Items.Add(dt.Rows[i]["CourseName"].ToString());
            DropDownList1.DataValueField = dt.Rows[i]["CourseID"].ToString();
            DropDownList1.DataTextField = dt.Rows[i]["CourseName"].ToString();
        }
        }        
    
    }
