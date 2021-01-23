    internal static string[] Raum()
    {
        List<object> raumObject = new List<object>();
        using (SqlConnection con = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=BOOK-IT-V2;Integrated Security=true;"))
        using (SqlCommand cmd = new SqlCommand(@"SELECT NAME, EMAIL FROM RAUM", con))
        {
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    if (rdr["NAME"] != DBNull.Value && rdr["EMAIL"] != DBNull.Value)
                    {
                        raumObject.Add(new{
                             Name=rdr["NAME"].ToString(),
                             Email=rdr["EMAIL"].ToString()
                        });
                    }
                }
            }
        }
        return  new JavaScriptSerializer().Serialize(new{d=raumObject.ToArray()});
    }
