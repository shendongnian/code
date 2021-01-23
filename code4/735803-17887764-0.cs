    while(param != "0")
    {
      Console.WriteLine("Enter Username: ");
      param = Console.ReadLine();
      
      com = new SqlCommand("Select username from table_name", cn); 
      SqlDataReader reader = com.ExecuteReader();
    
      if( reader.HasRows)
      {
        while (reader.Read())
        {
          string FirstName1 = reader["FirstName"].ToString();
          if (FirstName1 != param.ToString()) 
          {
             Console.WriteLine();
             Console.WriteLine("Permission Granted for: {0}",FirstName1);
             param = 0;
          }
          return;
        }
      }
      else
      {
        Console.WriteLine();
        Console.WriteLine("Invalid username! Please try again. To quit, press 0.");
      }
     }
     cn.Close();
