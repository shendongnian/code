        [WebMethod]
        public string[] area(string prefixText)
        {
            List<string> listString = new List<string>();
            using (SqlConnection con = new SqlConnection("Initial Catalog=EMS;Server=S-CEMSDB01;User ID=sa;Password=sqltest"))
            {
                SqlCommand cm = new SqlCommand("select distinct eqp_location from EQUIPMENT where eqp_location like '" + prefixText + "%' order by eqp_location", con);
                con.Open();
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listString.Add((dr["eqp_location"].ToString()));
                        //c.FullName, serializer.Serialize(c))
                    }
                }
                dr.Close();
                dr.Dispose();
                con.Close();
            }
            string[] str = listString.ToArray();
            return str;
        }
