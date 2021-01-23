                  [WebMethod]
    public static List<string> GetAutoCompleteData(string Car)
    {
        string input = context.Request.QueryString["term"];
        List<string> result = new List<string>();
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CarsConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("select DISTINCT Car from T_Car where Car like '%'+ @SearchText +'%", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@SearchText", input);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["Car"].ToString());
                }
                return result;
            }
        }
    }
