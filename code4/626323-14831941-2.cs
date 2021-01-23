    public List<string> GetAuthors(string aurtherName)
    {
      
      using(var con = CreateConnection()//somehow )
      {   
        var command = con.CreateCommand();
         
        string sql = "SELECT * FROM Books WHERE Author='@value'";
         command.Parameters.AddWithValue("@value", aurtherName);
         command.CommandText = sql ;
    
        var list = new List<string>();
        while(reader.Read())
        {
           list.Add(reader["Author"].ToString())
        }
    
         return list;
      }
    }
