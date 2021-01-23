         using (OdbcConnection connection = new OdbcConnection(...))
         {
             connection.Open();
             using (OdbcCommand command = ...)
             {
                 command.ExecuteNonQuery();
             }
         }
