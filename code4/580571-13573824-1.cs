    private void InsertData(string connectionString, string firstName, string lastname, string username, string password
                            int Age, string gender, string contact)
    {
        // define INSERT query with parameters
        string query = "INSERT INTO dbo.regist (FirstName, Lastname, Username, Password, Age, Gender,Contact) " + 
                       "VALUES (@FirstName, @Lastname, @Username, @Password, @Age, @Gender, @Contact) ";
        
        // create connection and command
        using(SqlConnection cn = new SqlConnection(connectionString))
        using(SqlCommand cmd = new SqlCommand(query, cn))
        {
            // define parameters and their values
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
            cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 50).Value = lastName;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = userName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = age;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = gender;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar, 50).Value = contact;
            
            // open connection, execute INSERT, close connection
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
