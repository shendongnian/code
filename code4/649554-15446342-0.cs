    public static User selectUser(string userName, string password)
    {
        User aUser = new User();
        if (sConnection.State == ConnectionState.Closed)
            sConnection.Open();
        OleDbCommand cmd = sConnection.CreateCommand();
        OleDbDataReader dbReader = null;
        string sql = "SELECT * FROM [User] WHERE ([userName]='" + userName + "' AND [Password]='" + password + "')";
                        cmd.CommandText = sql;
            dbReader = cmd.ExecuteReader();
        try
        {
            while (dbReader.Read())
            {
                if (dbReader.HasRows)
                {
                    MessageBox.Show("Login successful!");
                    aUser.UserName = username;
                    return aUser;
                }
                else
                {
                    MessageBox.Show("Login failed");
                    aUser.UserName =string.empty;
                }
            }
        }
        catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                aUser.UserName = string.empty;
            }
        return aUser;
    }
 
</pre>
