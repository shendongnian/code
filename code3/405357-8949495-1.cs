    public static List<string> LoadCitiesByState(string state)
    {
        List<string> cities = new List<string>();
        try {
            DataTable dt = SharedDataAccess.GetCities(state);
        } catch // specify exceptions here
        {
            //exception handling
        }
        foreach (DataRow row in dt.Rows)
        {
            cities.Add(row[0].ToString());
        }
        return cities;
    }
