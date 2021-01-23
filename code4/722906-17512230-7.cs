    DataTable dt = SqlComm.SqlDataTable(
        "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password",
        new Dictionary<string, object>
        {
            { "UserName", login.Text },
            { "Password", password.Text },
        }
    );
    
    if (dt.Rows.Count > 0)
    {
       // do something if the query returns rows
    }
