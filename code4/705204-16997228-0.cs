    using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
    {
        myDatabaseConnection.Open();
        using (SqlCommand SqlCommand = new SqlCommand("Select ID, LastName from Employee", myDatabaseConnection))
        {
            SqlDataReader dr = SqlCommand.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["LastName"].ToString().PadRight(50) + dr["ID"]);
            }
        }
    }
