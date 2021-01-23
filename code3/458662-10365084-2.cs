    string con=@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\John\Desktop\database practise\db1\db1\Setup.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    public bool SavePeople(string peopleName)
    {
       try
       {
          using (SqlConnection objConnection = new SqlConnection(con))
          {
            SqlCommand objCommand = new SqlCommand("SavePeople", objConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@peopleName", peopleName);       
            objConnection.Open();
            objCommand.ExecuteNonQuery();       
          }
          return true;
       }
       catch(Exception ex)
       {
          //You want to log the ex
       }
       return false; 
    }
