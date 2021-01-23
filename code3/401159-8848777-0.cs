     protected void Page_Load(object sender, EventArgs e)
     {
          if(Page.IsPostBack == false)
          {
             DataTable CityMembersTable = GetCity();
             ddlCity.DataSource = CityMembersTable;
             ddlCity.DataTextField = "CityName";
             ddlCity.DataValueField = "CityID";
             ddlCity.DataBind();
             ddlCity.Items.Insert(0, new ListItem("<--Choose City-->", ""));
          }
     }
     protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
     {
        ddlCity.SelectedIndex = 0; //Put this here
        if (ddlCity.SelectedValue == "")
        {
            return;
        }
     }
