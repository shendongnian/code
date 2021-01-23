    public class RaumklassenHelper
    {
        internal static string[] Raumklasse()
        {
            List<string> raumKlassenObject = new List<string>();
            using (SqlConnection con = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=BOOK-IT-V2;Integrated Security=true;"))
            using (SqlCommand cmd = new SqlCommand(@"SELECT BEZEICHNUNG FROM RAUMKLASSE", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (rdr["BEZEICHNUNG"] != DBNull.Value)
                        {
                            raumKlassenObject.Add(rdr["BEZEICHNUNG"].ToString());
                        }
                    }
                }
            }
            return raumKlassenObject.ToArray();
        }
    }
