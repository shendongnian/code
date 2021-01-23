    ddlCountryCode.DataSource = ds1.Tables["AUser"];
    ddlCountryCode.DataTextField = "CountryCode";
    ddlCountryCode.DataBind();
    
    ddlCountryCode.SelectedIndex = 
             ddlCountryCode.Items.IndexOf(ddlCountryCode.Items.FindByText("India(+91)"));
