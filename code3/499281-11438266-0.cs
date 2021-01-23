    using(SqlConnection connection = new SqlConnection("YourDatabaseConnectionString"))
    {
    
        string sqlStatement = "DELETE FROM Customers WHERE ColumnID = @ColumnID AND ColumnName2=@SecondValue";
         SqlCommand cmd = new SqlCommand(sqlStatement, connection);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.AddWithValue("@ColumnID", "SomeValueHere");
         cmd.Parameters.AddWithValue("@SecondValue", "OtherValue");
    
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
