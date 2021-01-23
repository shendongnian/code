    using (SqlConnection myConnection = new SqlConnection("Data Source=.\\SERVER;Initial Catalog=DB;Integrated Security=True;TrustServerCertificate=True;User Instance=False"))
    using (SqlCommand myCommand = myConnection.CreateCommand())
    {
        myConnection.Open();
        myCommand.CommandText = "SELECT BusinessName FROM Businessess WHERE BusinessID = @Param2";
        myCommand.Parameters.AddWithValue("@Param2", myParam2);
        using (SqlDataReader reader = myCommand.ExecuteReader())
        {
            if (reader.Read())
            {
                string businessName = reader.GetString(reader.GetOrdinal("BusinessName"));
                MessageBox.Show(businessName);
            }
            else
            {
                MessageBox.Show(string.Format("Sorry, no business found with id = {0}", myParam2));
            }
        }
    }
