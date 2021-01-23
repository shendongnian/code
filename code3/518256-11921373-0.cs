    private void GetData(String email)
    {
      String sqlStatement = "select * from Programs where Something = " + email;
      try
      {
        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStatement, _CONNECTION_STRING))
        {
          DataSet dataSet = new DataSet("Items");
          adapter.Fill(dataSet, "Items");
        }
        }
      catch (Exception) { }
      // Here you just type "dataSet." and the intellisense will 
      // present you with options to access the tables, rows etc.
    }
