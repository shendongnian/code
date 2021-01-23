    using (SqlConnection con = new SqlConnection(CommonFunctions.GetAppDBConnection(Constants.AppID, Constants.TMDDBConnection)))
    {
            con.Open();
    	    SqlDataAdapter da = new SqlDataAdapter("select * from MSUnit", con);
            DataTable dt = new DataTable
    	    da.Fill(dt)
            ddlTransactionCategory.DataSource = dt;
            ddlTransactionCategory.DataTextField = "categoryCode";
            ddlTransactionCategory.DataValueField = "OrgID";
            ddlTransactionCategory.DataBind();
    }
