    using(SqlConnection sqlConnection = new SqlConnection("Database Connection String Here"))
    {
         string command =
               "UPDATE Production.Product " +
               "SET ListPrice = ListPrice * 2 " +
               "WHERE ProductID IN " +
                   "(SELECT ProductID  " +
                    "FROM Purchasing.ProductVendor" +
                    "WHERE BusinessEntityID = 1540);" +
    
         using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
         {
               int execute = command.ExecuteNonQuery();
               if( execute <= 0)
               {
                   return false;
               }
               else
               {
                   return true;
               }
         }
    }
