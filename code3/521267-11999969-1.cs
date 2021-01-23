    public void getuserinfo()
    {
        var connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["KKSTechConnectionString"].ConnectionString;
    
        // this query should be parameterised when used in production to avoid SQL injection attacks
        var query = String.Format("SELECT Username, Pass FROM Users WHERE Username='{0}' AND Pass='{1}'",
                        txtUserName.Text,
                        txtPassword.Text.GetMd5Hash());
    
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
