    protected void Page_Load(object sender, EventArgs e)
    {
        //Session
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("LHLogin.aspx");
        }
        else
        {
            getUsername.Text = Session["userSessionU"].ToString();
        }
       getUserSessionStatus =  Session["userAccountType"].ToString();
        //if super admin, show super admin controls
       if (getUserSessionStatus == "Super-Admin")
       {
           adminOptions.Visible = true;
       }
       else
       {
           adminOptions.Visible = false;
       }
        if (!IsPostBack)
        {
            GridView2.DataSourceID = "SqlDataSource1";
            GridView1.DataBind();
            GridView2.DataSourceID = "SqlDataSource2";
            GridView2.DataBind();
            
        }
        //display for divs
       // topPanel.Visible = false;
        temp.Attributes.CssStyle.Add("opacity", "0.6");
        //computerTable.Visible = false;
        //refresh gridviews
        SqlDataSource2.DataBind();
        GridView2.DataBind();
        //hash password session string
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPW"].ToString() + "", "SHA1");
        //get the users last name
        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["legalHoldConnString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT lhulname FROM lhusers WHERE lhUUsername = '" + getUsername.Text + "' AND lhupassword = '" + hash + "';");
            cmd.Connection = con;
            getLastName = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
            // Response.Write(getCustomView);
        }
        catch (Exception)
        {
        }
        //get the users first name
        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["legalHoldConnString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT lhufname FROM lhusers WHERE lhUUsername = '" + getUsername.Text + "' AND lhupassword = '" + hash + "';");
            cmd.Connection = con;
            getFirstName = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
            // Response.Write(getCustomView);
        }
        catch (Exception)
        {
        }
        
        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["legalHoldConnString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT lhuCustomeView FROM lhusers WHERE lhUUsername = '" + getUsername.Text + "' AND lhupassword = '"+ hash +"';");
            cmd.Connection = con;
            getCustomView = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
           // Response.Write(getCustomView);
        }
        catch (Exception)
        {
            
        }
        
        //clear the customview string
        
        //adv search options for entries
        //------   ----------------------
       
        //////////////////////////////////////////////////////////////
        searchBtn.Focus();
        SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheNameID LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        if (firstNameRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheFName LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (lastNameRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheLName LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (emailRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lhePrimaryEmail LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (displayNameRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheDisplayName LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (nameID.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheNameID LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (whosLookingAtThis.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lheWhosLookingAtthis LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else if (wirelessGiantRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE (lhewirelessGiant LIKE '%" + searchEntryTable.Text.ToString() + "%' ) ORDER BY lheID DESC";
        }
        else 
        {
            nameID.Checked = true;
        }
        //////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //for my table entries
        if (Session["getSearchForMyTable"] != null)
       {
           SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheNameID LIKE '%" + searchMyTable.Text.ToString() + "%' ) AND lheCompleted = 'False' ORDER BY lheID DESC;";
        if (firstNameRB.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheFName LIKE '%" + searchMyTable.Text.ToString() + "%' ) AND lheCompleted = 'False' ORDER BY lheID DESC;";
        }
        else if (lastNameRB.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheLName LIKE '%" + searchMyTable.Text.ToString() + "%' )  AND lheCompleted = 'False' ORDER BY lheID DESC;";
        }
        else if (emailRB.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lhePrimaryEmail LIKE '%" + searchMyTable.Text.ToString() + "%' )  AND lheCompleted = 'False' ORDER BY lheID DESC;";
        }
        else if (displayNameRB.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheDisplayName LIKE '%" + searchMyTable.Text.ToString() + "%' )  AND lheCompleted = 'False' ORDER BY lheID DESC;";
        }
        else if (nameID.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheNameID LIKE '%" + searchMyTable.Text.ToString() + "%' )  AND lheCompleted = 'False' ORDER BY lheID DESC;";
            // Response.Write("this test works if u can se ethis");
        }
        else if (whosLookingAtThis.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lheWhosLookingAtthis LIKE '%" + searchMyTable.Text.ToString() + "%' ) AND lheCompleted = 'False' ORDER BY lheID DESC;";
        }
        else if (wirelessGiantRB.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries  WHERE  lheID IN (" + getCustomView + ") AND (lhewirelessGiant LIKE '%" + searchMyTable.Text.ToString() + "%' )  AND lheCompleted = 'False' ORDER BY lheID DESC;";
        
        }
       }
        if ((getCustomView == null) )
        {
            //Perform the custom view with the select command
            SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries WHERE lheID  = 0  AND lheCompleted = 'False' ORDER BY lheID DESC; ";
        }
        else
        {
            try
            {
                //Perform the custom view with the select command
                SqlDataSource2.SelectCommand = "SELECT lheID, lhewirelessGiant, lheFName, lheInitials, lheLName, lhePrimaryEmail, lheDisplayName, lheNameID, lheWhosLookingAtthis FROM lhentries WHERE lheID IN (" + getCustomView + ")  AND lheCompleted = 'False' ORDER BY lheID DESC; ";
            }
            catch (Exception ex) { }
        }
        getCustomView = null;
    }
