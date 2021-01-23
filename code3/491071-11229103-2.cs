    //C#
    string connString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
    using (SqlConnection conn = new SqlConnection(connString))
    {
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT CustomerId, CompanyName FROM Customers";
      
      conn.Open();
    
      using (SqlDataReader dr = cmd.ExecuteReader())
      {
        while (dr.Read())
          Console.WriteLine("{0}\t{1}", dr.GetString(0), dr.GetString(1));
      }
    }
