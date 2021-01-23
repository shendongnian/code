            SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText =
              "INSERT INTO Customers (" +
              "  CustomerID, CompanyName, ContactName" +
              ") VALUES (" +
              "  @CustomerID, @CompanyName, @ContactName" +
              ")";
            mySqlCommand.Parameters.Add("@CustomerID", SqlDbType.NChar, 5);
            mySqlCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40);
            mySqlCommand.Parameters.Add("@ContactName", SqlDbType.NVarChar, 30);
            mySqlCommand.Parameters["@CustomerID"].Value = "J4COM";
            mySqlCommand.Parameters["@CompanyName"].Value = "J4 Company";
            mySqlCommand.Parameters["@ContactName"].IsNullable = true;
            mySqlCommand.Parameters["@ContactName"].Value = DBNull.Value;
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("Successfully added row to Customers table");
    
            mySqlConnection.Close();
        }
    }
