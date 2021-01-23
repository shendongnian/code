    public static List<T> DropDownPopulating<T>(string selectedFilter)
    {
        var returnVal = new List<T>();
        using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteContent"].ConnectionString))
        {
            sqlCon.Open();
            string SQL = "SELECT DISTINCT " + selectedFilter + " FROM Placements";
            using (var CMD = new SqlCommand(SQL, sqlCon))
            using (var DR = CMD.ExecuteReader())
            {
                while (DR.Read())
                {
                    // if you are using .NET 4.5
                    returnVal.Add(DR.GetFieldValue<T>(DR.GetOrdinal(selectedFilter)));
                    // if you are using .NET 4.0 or older:
                    // returnVal.Add((T)DR.GetValue(DR.GetOrdinal(selectedFilter)));
                }
            }
        }
        return returnVal;
    }
