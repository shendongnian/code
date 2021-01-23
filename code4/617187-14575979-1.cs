    public AdvertisementDAL selectAdvertisementLocation1(DateTime now, string gender)
        {
            AdvertisementDAL dal = null;
            string sql = "Select * From Advertisement Where @currentDate between StartDate AND EndDate AND TargetAudience = @gender AND Location = 1";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@currentDate", now);
            cmd.Parameters.AddWithValue("@gender", gender);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            _advertisementID = int.Parse(dr["AdvertisementID"].ToString());
            _location = int.Parse(dr["Location"].ToString());
            _image = dr["Image"].ToString();
            _targetAudience = dr["TargetAudience"].ToString();
            _url = dr["Url"].ToString();
            _onMouseOverText = dr["OnMouseOverText"].ToString();
            dal = new AdvertisementDAL(_advertisementID, _location, _image, _targetAudience,
                _url, _onMouseOverText);
           System.IO.StreamWriter file = new System.IO.StreamWriter(
        @"c:\temp\SerializationOverview.xml"); //rmb to create the file
    writer.Serialize(file, dal);
    file.Close();
        }
        conn.Close();
        dr.Close();
        dr.Dispose();
        return dal;
    }
