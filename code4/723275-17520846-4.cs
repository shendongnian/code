    try
    {
         SqlConnection thisConnection = new SqlConnection(@"Network Library=DBMSSOCN;Data Source=192.168.0.100,1433;database=Northwind;User id=Paladine;Password=;");
         thisConnection.Open();
         SqlCommand thisCommand = thisConnection.CreateCommand();
         thisCommand.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
         SqlDataReader thisReader = thisCommand.ExecuteReader();
         while (thisReader.Read())
         {
                  Console.WriteLine("\t{0}\t{1}", thisReader["CustomerID"], thisReader["CompanyName"]);
         }
         thisReader.Close();
         thisConnection.Close();
    }
    catch (SqlException e)
    {
         Console.WriteLine(e.Message);
    }
