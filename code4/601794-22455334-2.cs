    Class DbManager
    {
     SqlConnection connection;
     SqlCommand command;
           public DbManager()
          {
            connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=.     \SQLEXPRESS;AttachDbFilename=|DataDirectory|DatabaseName.mdf;Integrated Security=True;User Instance=True";
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
         } // constructor
     public bool GetUsersData(ref string lastname, ref string firstname, ref string age)
         {
            bool returnvalue = false;
            try
            {
                command.CommandText = "select * from TableName where firstname=@firstname and lastname=@lastname";
                command.Parameters.Add("firstname",SqlDbType.VarChar).Value = firstname;
     command.Parameters.Add("lastname",SqlDbType.VarChar).Value = lastname; 
                connection.Open();
                SqlDataReader reader= command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lastname = reader.GetString(1);
                        firstname = reader.GetString(2);
                        age = reader.GetString(3);
                                                 
                  
                    }
                }
                returnvalue = true;
            }
            catch
            { }
            finally
            {
                connection.Close();
            }
            return returnvalue;
        }
 
