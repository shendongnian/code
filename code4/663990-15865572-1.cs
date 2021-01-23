    public static List<T> DropDownPopulating<T>(string selectedFilter)
    {
        var returnVal = new List<T>();
        var connectionString = ConfigurationManager.ConnectionStrings["websiteContent"].ConnectionString;
        using (var con = new SqlConnection(connectionString))
        using (var cmd = con.CreateCommand())
        {
            con.Open();
            cmd.CommandText = "SELECT DISTINCT " + selectedFilter + " FROM Placements";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // if you are using .NET 4.5
                    returnVal.Add(reader.GetFieldValue<T>(reader.GetOrdinal(selectedFilter)));
                    // if you are using .NET 4.0 or older:
                    // returnVal.Add((T)reader.GetValue(reader.GetOrdinal(selectedFilter)));
                }
            }
        }
        return returnVal;
    }
