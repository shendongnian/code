    public List<Vehicle> Vehiclelist(string Vehicle)
    {
        var result = new List<Vehicle>();
        using (SqlConnection conn = new SqlConnection("PUT YOUR CONNECTION STRING HERE"))    
        using (SqlCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT * from  where Vehicle_No = @Vehicle_No";
            cmd.Parameters.AddWithValue("@Vehicle_No", Vehicle);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var vehicle = new Vehicle
                    {
                        Number = reader.GetInt32(reader.ReadOrdinal("Vehicle_No")),
                        Make = reader.GetString(reader.ReadOrdinal("Vehicle_Make")),
                        Model = reader.GetString(reader.ReadOrdinal("Vehicle_Model"))
                    };
                    result.Add(vehicle);
                }
            }
    
            return result;
        }
    }
