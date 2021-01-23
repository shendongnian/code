    using (SqlCommand cmd = new SqlCommand(@"SELECT r.NAME AS rName, s.NAME AS sName FROM REGION r LEFT OUTER JOIN STADT s ON s.REGION_ID = r.ID ORDER BY r.NAME", con))
    {
        con.Open();
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                if (rdr["rNAME"] != DBNull.Value && rdr["sNAME"] != DBNull.Value)
                {
                    stadtObject.Add(new STADT()
                    {
                        RegionName = rdr["rNAME"].ToString(),
                        StadtName = rdr["sNAME"].ToString()
                    });
                }
            }
        }
    }
