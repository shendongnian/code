    private void UpdateEmployeeInfo(string username, string name, string jobTitle, string badgeNo, string division,string divisioncode)
    {
        string connString = ConfigurationManager.ConnectionStrings["UsersInfoDBConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string update = @"UPDATE Employee SET Name = @Name, JobTitle = @JobTitle, 
                            BadgeNo = @BadgeNo WHERE Username = @Username; 
                            UPDATE Divisions SET [DivisionShortcut] = @division WHERE SapCode = @SapCode;";
    
        SqlCommand cmd = new SqlCommand(update, conn);
    
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
        cmd.Parameters.AddWithValue("@BadgeNo", badgeNo);
        cmd.Parameters.AddWithValue("@division", division);
        cmd.Parameters.AddWithValue("@Username", username);
        cmd.Parameters.AddWithValue("@DapCode", divisioncode);
    
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
    
            GridView1.EditIndex = -1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        GridView1.DataBind();
    }
