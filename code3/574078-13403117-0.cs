    SqlDataReader reader = command.ExecuteReader();
    // Call Read before accessing data. 
    while (reader.Read())
    {
        cmd.Parameters.AddWithValue("@param1", Reader.GetString(0));
    }
    // Call Close when done reading.
    reader.Close();
