    // Your Connection string
    string connectionString = "Data Source=DELL-PC;initial catalog=AdventureWorks2008R2 ; User ID=sa;Password=sqlpass;Integrated Security=SSPI;";
    
    // Collecting Values
    string firstName="Name",
    	lastName="LastName",
    	userName="UserName",
    	password="123",
    	gender="Male",
    	contact="Contact";
    int age=26;	
    
    // Query to be executed
    string query = "Insert Into dbo.regist (FirstName, Lastname, Username, Password, Age, Gender,Contact) " + 
                       "VALUES (@FN, @LN, @UN, @Pass, @Age, @Gender, @Contact) ";
    
        // instance connection and command
        using(SqlConnection cn = new SqlConnection(connectionString))
        using(SqlCommand cmd = new SqlCommand(query, cn))
        {
            // add parameters and their values
            cmd.Parameters.Add("@FN", System.Data.SqlDbType.NVarChar, 100).Value = firstName;
            cmd.Parameters.Add("@LN", System.Data.SqlDbType.NVarChar, 100).Value = lastName;
            cmd.Parameters.Add("@UN", System.Data.SqlDbType.NVarChar, 100).Value = userName;
            cmd.Parameters.Add("@Pass", System.Data.SqlDbType.NVarChar, 100).Value = password;
            cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = age;
            cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 100).Value = gender;
            cmd.Parameters.Add("@Contact", System.Data.SqlDbType.NVarChar, 100).Value = contact;
    
            // open connection, execute command and close connection
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }	 
