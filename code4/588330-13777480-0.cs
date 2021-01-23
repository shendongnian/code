    public static bool isMember(string userid)
    {
        // guard clause - if "userid" is invalid, return "false" right away 
        if (String.IsNullOrEmpty(userid))
        {
            return false
        }
        PTEmployee employee = new PTEmployee(userid);
        string username = userid;
        string connString = "Data Source=appServer\\sqlexpress;Initial Catalog=dbTest;Integrated Security=True";
        string cmdText2 = "SELECT Count(*) FROM employee WHERE Username = @username";
        using (SqlConnection conn = new SqlConnection(connString))
        using (SqlCommand cmd = new SqlCommand(cmdText2, conn))
        {
                cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;
                conn.Open();
                var count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                   return true; // return true if there's only one employee with given name
                }
        }
        // if the user already existed in the database - then the above RETURN has 
        // returned "true" to the caller. So these lines are **only** executed if the
        // user was NOT found in the database.
        if (employee.department.Code == "30003143") //The SapCode of department is "30003143"
            return true;
        // now check in Active Directory here.....     
        return UserExistsInActiveDirectory();
    }
