    public void Save()
    {
      string yourConnString="Replace with Your Database ConnectionString";
      using(SqlConnection connection = new SqlConnection(yourConnString))
      {    
         string sqlStatement = "INSERT Table1(Data1) VALUES(@Data1)";
         using(SqlCommand cmd = new SqlCommand(sqlStatement, connection))
         {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Data1",Data1);
           //add more parameters as needed  and update insert query
    
            try
            {
               connection.Open();
               cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
              //log error
            }    
         }
      }
     }
