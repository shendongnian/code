    public int GetUserRole(string CUSER)
    {
        try
        {
            SQLCON = new SqlConnection(connectionString);
            SQLCON.Open();
            SQLCommand = new SqlCommand();
            SQLCommand.CommandType = CommandType.Text;
            SQLCommand.Parameters.Add("USUsername", SqlDbType.VarChar).Value = CUSER;
            SQLCommand.CommandText = "SELECT USRole FROM tblUser WHERE USUsername = @USUsername";
            Int32 USRole = (Int32) SQLCommand.ExecuteScalar();
            return USRole;
        }
        catch (Exception)
        {
            HttpContext.Current.Response.Redirect("~/ErrorRedirect.aspx", false);
            return 0;
        }
    }
