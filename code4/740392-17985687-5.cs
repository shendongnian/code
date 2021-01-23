    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Add other functions you want to perform here
            // like setting the visibility of the dropdowns
    
            FillddlLocations();
        }
        //Add other functions you want to perform here
    }
    
    
    protected void FillddlLocations()
    {
        FillDropdown(memberID1);
        FillDropdown(memberID2);
        FillDropdown(memberID3);
        memberID1.Visible = true;
        memberID2.Visible = true;
        memberID3.Visible = true;
    }
    
    protected void FillDropdown(DropDownList ddl)
    {
        //Remove dummy data and uncomment code after testing
    
        //using (var connAdd = new SqlConnection("Data Source = localhost; Initial Catalog = MajorProject; Integrated Security= SSPI"))
        //{
        //    connAdd.Open();
    
        //    var sql = "Select policeid from PoliceAccount where status ='available' and handle ='offcase' and postedto='" + ddllocation.SelectedValue + "'";
        //    using (var cmdAdd = new SqlDataAdapter(sql, connAdd))
        //    {
        //DataSet ds2 = new DataSet();
        //cmdAdd.Fill(ds2);
        var ds2 = new List<ListItem>{ new ListItem{Value="1", Text="12345"},
                                new ListItem{Value="2", Text="23456"},
                                new ListItem{Value="3", Text = "34567"}};
        ddl.Items.Clear();
        ddl.DataSource = ds2;
        //ddl.DataTextField = "memberID";
        //ddl.DataValueField = "memberID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Please select a Member ID", ""));
        ddl.SelectedIndex = 0;
    
        //    }
    
        //}
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
    
    protected void ddlpid2_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
    protected void ddlpid3_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
