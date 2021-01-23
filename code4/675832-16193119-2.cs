    // connect to the database
    using (SqlConnection c = new SqlConnection("connection string"))
    {
        // count the logged in users
        var loggedInUsers = (int)new SqlCommand("SELECT COUNT(UserId) FROM Users WHERE status = 1", c).ExecuteScalar();
        // if the threshold has been met then shut down the application
        if (loggedInUsers == 3)
        {
            MessageBox.Show("There are already 3 concurrent users logged into the system -please try again at a later time.", "User Limit Met", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
