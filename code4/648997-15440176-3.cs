        XmlTextWriter writer = new XmlTextWriter(...);
        writer.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
        ...
        writer.WriteStartElement("LineString");
        StringBuilder sb = new StringBuilder();
        foreach (string point in route)
        {
            string[] route_point = point.Split(delimiterPoint);
            if (route_point.Length >= 2)
            {
              double lon = double.Parse(route_point[0]);
              double lat = double.Parse(route_point[1]);
              sb.Append(' ').Append(lon).Append(',').Append(lat);
              // coordinates.Add(new Vector(lat, lon));
            }
        }
        writer.WriteStartElement("coordinates");
        writer.WriteValue(sb.ToString());
        writer.WriteEndElement(); // end coordinates
        writer.WriteEndElement(); // end LineString
        writer.WriteEndElement(); // end Placemark
        ...
        writer.Close();
