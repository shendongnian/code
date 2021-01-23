    private string MembershipAddUser(string firstName, string lastName)
    {
        string username = firstName + "." + lastName;
        int i = 0;
        while (UserExists(username))
        {
            i++;
            username = firstName + "." + lastName + i.ToString();
        }
        return username;
    }
    private bool UserExists(string username)
    {
        string sql = "SELECT COUNT(*) FROM dbo.aspnet_Users WHERE UserName = @UserName";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@UserName", username);
        using (connection)
        {
            connection.Open();
            int count = (int) command.ExecuteScalar();
            return (count != 0);
        }
    }
