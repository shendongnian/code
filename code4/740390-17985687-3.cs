    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //Add other functions you want to perform here
           // like setting the visibility of the dropdowns
           FillddlLocations();
           //Add other functions you want to perform here
        }
    }
    protected void FillddlLocations()
    {
        FillDropdown(memberID1);
        FillDropdown(memberID2);
        FillDropdown(memberID3);
    }
    protected void FillDropdown(DropDownList ddl)
    {
        using (var connAdd = new SqlConnection("Data Source = localhost; Initial Catalog = MajorProject; Integrated Security= SSPI"))
        {
            connAdd.Open();
            var sql = "Select policeid from PoliceAccount where status ='available' and handle ='offcase' and postedto='" + ddllocation.SelectedValue + "'";
            using (var cmdAdd = new SqlDataAdapter(sql, connAdd))
            {
                DataSet ds2 = new DataSet();
                cmdAdd.Fill(ds2);
                ddl.Items.Clear();
                ddl.DataSource = ds2;
                ddl.DataTextField = "memberID";
                ddl.DataValueField = "memberID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Please select a Member ID", ""));
                ddl.SelectedIndex = 0;
            }
        }
    }
    protected void ddlpid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropdown(memberID2);
        FillDropdown(memberID3);
        if (memberID1.SelectedIndex > 0)
        {
            ListItem removeItem2 = memberID2.Items.FindByValue(memberID1.SelectedValue);
            memberID2.Items.Remove(removeItem2);
            ListItem removeItem3 = memberID3.Items.FindByValue(memberID1.SelectedValue);
            memberID3.Items.Remove(removeItem3);
        }
    }
