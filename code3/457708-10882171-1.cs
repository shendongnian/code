    using System;
    using System.Data;
    using System.Data.Odbc;
       class myOdbc
       {
          static void Main()
          {
          OdbcConnection myOdbcCommandConnection = new OdbcConnection("..."); 
    
          myOdbcCommandConnection.Open();
    
          OdbcCommand myOdbcCommand = myOdbcCommandConnection.CreateCommand();
    
          myOdbcCommand.CommandText = "INSERT INTO table1 (field1, field2) VALUES (?, ?)";
    
          myOdbcCommand.Parameters.Add("@field1", OdbcType.Int);
          myOdbcCommand.Parameters.Add("@field2", OdbcType.Int);
            
          myOdbcCommand.Parameters["@field1"].Value = 1;
          myOdbcCommand.Parameters["@field2"].Value = 2;
    
          Console.WriteLine("Number of Rows Affected is: {0}", myOdbcCommand.ExecuteNonQuery());
    
          myOdbcCommandConnection.Close();
    
          Console.ReadKey();
          }
       }
