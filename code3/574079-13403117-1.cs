    SqlDataReader reader = command.ExecuteReader();
    // Call Read before accessing data. 
    while (reader.Read())
    {
       if (!reader.IsDBnull(0))
       { 
           cmd.Parameters.AddWithValue("@param1", Reader.GetString(0));
       }
    }
    // Call Close when done reading.
    reader.Close();
