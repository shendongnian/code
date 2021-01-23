    public static List<string> GetAllPlacements(string placementLocation)
        {
            string returnVal = new List<string>;
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteContent"].ConnectionString))
            {
                sqlCon.Open();
                string SQL = "SELECT DISTINCT " + placementLocation + " FROM Placements";
                using (var CMD = new SqlCommand(SQL, sqlCon))
                {
                    using (var DR = CMD.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            returnVal.Add(DR[selectField].ToString());
                        }
                    }
                }
                sqlCon.Close();
            }
            return returnVal;
        }
