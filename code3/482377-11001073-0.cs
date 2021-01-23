        var doc = new Document();
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            using (cmd)
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double lat = reader.GetDouble(1);
                    double lon = reader.GetDouble(2);
                    string country = reader.GetString(3);
                    string county = reader.GetString(4);
                    double TIV = reader.GetDouble(5);
                    double cnpshare = reader.GetDouble(6);
                    double locshare = reader.GetDouble(7);
                    var point = new Point();
                    point.Coordinate = new Vector(lat , lon );
                    var placemark = new Placemark();
                    placemark.Geometry = point;
                    placemark.Name = Convert.ToString(TIV);
                    doc.AddFeature(placemark);
                reader.Close();
            }
            conn.Close();
        }
