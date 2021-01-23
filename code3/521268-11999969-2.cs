    public void ValidateUser()
    {
        var connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["KKSTechConnectionString"].ConnectionString;
        var userName = txtUserName.Text;
        var hashedPassword = Helper.ComputeHash(txtPassword.Text, "SHA512", null);
        // this query should be parameterised when used in production to avoid SQL injection attacks
        var query = String.Format("SELECT Username, Pass FROM Users WHERE Username='{0}' AND Pass='{1}'",
                        userName,
                        hashedPassword);
    
        using(var connection = new SqlConnection( connectionString ))
        using(var command = new SqlCommand(query, connection ))
        {
            conn.Open();
            SqlDataReader reader=command.ExecuteReader();
            if(reader.Read())
            {
    
            }
            reader.Close();
        }
    }
