    var selectedItems = new List<string>{ "WHERE "});
    foreach (ListItem item in chkGeneralSkills.Items)
    {
    if (item.selected)
    {
    if (!selectedItems.Any())
    selectedItems.Add(" sl.SkillTitle = " + item.text)
    else
    selectedItems.Add(" AND sl.SkillTitle = " + item.text)
    }
    }
    using (SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString()))
                        {
                            string sql = "SELECT us.FName + ' ' + us.SName As 'Name', " +
                                     "sk.SkillsID, sl.SkillTitle " +
                                     "FROM Users us " +
                                     "LEFT JOIN Skills sk ON sk.UserID = us.UserID " +
                                     "LEFT JOIN SkillsListing sl ON sl.SkillsListingID = sk.SkillsListingID " + string.Join(" ", selectedItems);
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
