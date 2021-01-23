    // Build a WHERE clause according to each SELECTED item in the list
    var selectedItems = new List<string>{ "WHERE "});
    foreach (ListItem item in chkGeneralSkills.Items)
    {
    	if (item.selected)
    	{       
                // if there are no items in the list, omit the AND
    		if (!selectedItems.Any())
    			selectedItems.Add(" sl.SkillTitle = " + item.text)
    		else // otherwise, add the AND
    			selectedItems.Add(" AND sl.SkillTitle = " + item.text)
    	}
    }
    
    using (SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString()))
    {
        string sql = "SELECT us.FName + ' ' + us.SName As 'Name', " +
                    "sk.SkillsID, sl.SkillTitle " +
                    "FROM Users us " +
                    "LEFT JOIN Skills sk ON sk.UserID = us.UserID " +
                    "LEFT JOIN SkillsListing sl ON sl.SkillsListingID = sk.SkillsListingID " + 
    // join together the items in the string list to make the where clause for Sql Server
    string.Join(" ", selectedItems.ToArray());
        try
        {
            oConn.Open();
            SqlCommand cmd = new SqlCommand(sql, oConn);
            SqlDataReader reader = cmd.ExecuteReader();
            chkMatchedUsers.DataTextField = "Name";
            chkMatchedUsers.DataValueField = "Name";
            chkMatchedUsers.DataSource = reader;
    
            chkMatchedUsers.DataBind();
    
            oConn.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }
