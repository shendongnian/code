    using (SqlConnection myConnection = new SqlConnection("Data Source=.\\SERVER;Initial Catalog=DB;Integrated Security=True;TrustServerCertificate=True;User Instance=False"))
    using (SqlCommand myCommand = myConnection.CreateCommand())
    {
        myConnection.Open();
        myCommand.CommandText = "SELECT BusinessName FROM Businessess WHERE BusinessID = @Param2";
        myCommand.Parameters.AddWithValue("@Param2", myParam2);
        using (DbDataReader reader = myCommand.ExecuteReader())
        {
            // potentially you could have multiple rows thus the while
            // if you know that your query can match at most one row
            // you could use an "if (reader.Read())" statement. But in all
            // cases you should call at least once the .Read method on the reader
            // to advance it
            while (reader.Read())
            {
                string businessName = reader.GetString(reader.GetOrdinal("BusinessName"));
                MessageBox.Show(businessName);
            }
        }
    }
