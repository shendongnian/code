    [WebMethod]
    public static List<string> LoadCitiesByState(string state)
    {
       
        List<string> cities = new List<string>();
        try
        {
            DataTable dt = SharedDataAccess.GetCities(state);
            foreach (DataRow row in dt.Rows)
            {
                cities.Add(row[0].ToString());
            }
         }
         catch(Exception e)
         {
              //logs your exception 
         }
        return cities;
    }
