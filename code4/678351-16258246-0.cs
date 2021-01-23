    public enum Result
    {
        Busy,
        Empty,
        NotSame,
        Completed
    }
    public Result Check(string name, string lastName, string eMail, string userName, string password1, string password2)
    {
        if (name == "" || lastName == "" || eMail == "" || userName == "" || password1 == "" || password2 == "")
            return Result.Empty;
        
        if (password1 != password2)
            return Result.NotSame;
        
        using(SqlConnection con = new SqlConnection(@"Data Source=TALY-PC;Initial Catalog=TicTacToe;Integrated Security=True"))
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUsers WHERE UserName=@0", con);
            cmd.Parameters.AddWithValue("@0", userName);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return Result.Busy;
            // I must admit, also the insert values should be done with SqlParameters.
            cmd = new SqlCommand("INSERT INTO tblUsers (Name, LastName, email, Username, Password) VALUES ('" + name + "', '" + lastName + "', '" + eMail + "', '" + userName + "', '" + password1 + "')", con);
            cmd.ExecuteNonQuery();
            return Result.Completed;
        }
    }
 
