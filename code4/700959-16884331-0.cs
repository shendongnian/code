    using System;
        using System.Data.SqlClient;
      
      class ConnectToSqlConnection {
        static void Main(string[] args)  {
          String sConn = "server=(local)\\SQLEXPRESS;database=MyDatabase;Integrated Security=SSPI";
    
            String sSQL = "select id, firstname, lastname from Employee";
    
          SqlConnection oConn = new SqlConnection(sConn);
          oConn.Open();
    
          SqlCommand oCmd = new SqlCommand(sSQL, oConn);
          SqlDataReader oReader = oCmd.ExecuteReader();
    
          int idxID = oReader.GetOrdinal("id");
          int idxFirstName = oReader.GetOrdinal("firstname");
          int idxLastName = oReader.GetOrdinal("lastname");
    
          while(oReader.Read()) {
            Console.WriteLine("{0} {1} {2}",
              oReader.GetValue(idxID),
              oReader.GetValue(idxFirstName),
              oReader.GetValue(idxLastName));
          }
        }
