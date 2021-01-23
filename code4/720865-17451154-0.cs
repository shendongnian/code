    string updateString =
                        "UPDATE dbo.testTable SET datecol = @datecol where clientId=@clientID";
     conn.Open();
     using (SqlCommand cmd = new SqlCommand(updateString, conn))
           {
              
             cmd.Parameters.Add("@datecol", SqlDbType.Date).Value = DbNull.Value;
             cmd.Parameters.Add("@clientID", SqlDbType.Int).Value = 1212;
     
             cmd.ExecuteNonQuery();
           }
           conn.Close();
   
     
