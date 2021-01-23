    public List<Vehicle> Vehiclelist(string Vehicle)
    {
        var result = new List<Vehicle>();
        using (SqlConnection conn = new SqlConnection("PUT YOUR CONNECTION STRING HERE"))    
        using (SqlCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT * FROM Vehicles WHERE Vehicle_No = @Vehicle_No";
            cmd.Parameters.AddWithValue("@Vehicle_No", Vehicle);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Vehicle
                    {
                        Number = reader.GetInt32(reader.GetOrdinal("Vehicle_No")),
                        Make = reader.GetString(reader.GetOrdinal("Vehicle_Make")),
                        Model = reader.GetString(reader.GetOrdinal("Vehicle_Model"))
                    });
                }
            }
            return result;
        }
    }
