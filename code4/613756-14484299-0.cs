     using(var connection1 = new OdbcConnection("your connection string here"))
     {
       connection1.Open();
       using(var connection2 = new OdbcConnection("your connection string here"))
       {
         connection2.Open();
         using(var cmd1 = connection1.CreateCommand())
         {
           cmd1.CommandText = "YOU FIRST QUERY HERE";
           using(var dataReader1 = cmd1.ExecuteReader())
           {
              while(dataReader1.Read())
              {
                 // keep reading data from dataReader1 / connection 1
                 //  .. at some point you may need to execute a second query
                 using(var cmd2 = connection2.CreateCommand())
                 {
                    cmd2.CommandText = "YOUR SECOND QUERY HERE";
                    // you can now execute the second query here
                    using(var dataReader2 = cmd2.ExecuteReader())
                    {
                       while(dataReader2.Read())
                       {
                       }
                    }
                 }
              } 
           }
         }
         connection2.Close();
       }
       connection1.Close();
     }
