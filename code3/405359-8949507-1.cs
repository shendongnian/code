    [WebMethod]
    public static List<string> LoadCitiesByState(string state)
    {
        DataTable dt = SharedDataAccess.GetCities(state);
        List<string> cities = new List<string>();
        foreach (DataRow row in dt.Rows)
        {
            cities.Add(row[0].ToString());
        }
        return cities;
    }
