    String sql = "Select * From SomeTable Where [Name] = @Name and [Last_Name] = @LastName";
    try
    {
      using(SqlConnection conn = new SqlConnection(connection))
      {
        conn.Open();
        using( SqlCommand command = new SqlCommand(sql,conn))
        {
          command.Parameters.Add(new SqlParameter("Name", DbType.String,someName));
          command.Parameters.Add(new SqlParameter("LastName", DbType.String,someLastName));
          using(IDataReader myReader = command.ExecuteReader())
          {
            while (myReader.Read())
            {
               //do something
            }
          }
        }
      } 
      return 0; // Huh?
    }
    catch(SqlException sex)
    {
       Console.Writeline(String.Format("Error - {0}\r\n{1}",sex.Message, sex.StackTace))
    }
