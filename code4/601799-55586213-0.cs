    class Db
    {
        private readonly static string ConnectionString =
                ConfigurationManager.ConnectionStrings
                            ["DbConnectionString"].ConnectionString;
        public static List<string> GetValuesFromDB(string LocationCode)
        {
            List<string> ValuesFromDB = new List<string>();
            string LocationqueryString = "select BELocationCode,CityLocation,CityLocationDescription,CountryCode,CountryDescription " +
                $"from [CustomerLocations] where LocationCode='{LocationCode}';";
            using (SqlConnection Locationconnection =
                                     new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(LocationqueryString, Locationconnection);
                try
                {
                    Locationconnection.Open();
                    SqlDataReader Locationreader = command.ExecuteReader();
                    while (Locationreader.Read())
                    {
                        for (int i = 0; i <= Locationreader.FieldCount - 1; i++)
                        {
                            ValuesFromDB.Add(Locationreader[i].ToString());
                        }
                    }
                    Locationreader.Close();
                    return ValuesFromDB;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
