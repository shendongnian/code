    if(!Page.IsPostBack)
    {
    using (SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SFGSConnectionString1"].ConnectionString))
    {
        string selectQuery1 = "SELECT [profileID], [profileName], [positionID], [positionName] from vw_profile WHERE memberID=@memberID";
        SqlCommand cmd1 = new SqlCommand(selectQuery1, conn1);
        cmd1.Parameters.AddWithValue("@memberID", memberID);
    
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd1;
        DataSet ds = new DataSet();
        conn1.Open();
        da.Fill(ds);
        conn1.Close();
    
        chooseProfile.DataSource = ds;
        chooseProfile.DataTextField = "profileName";
        chooseProfile.DataValueField = "profileID";
        chooseProfile.DataBind();
    
        choosePosition.DataSource = ds;
        choosePosition.DataTextField = "positionName";
        choosePosition.DataValueField = "positionID";
        choosePosition.DataBind();
    }
    }
