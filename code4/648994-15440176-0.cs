        writer.WriteStartElement("coordinates");
        StringBuilder sb = new StringBuilder();
        foreach (string point in route)
        {
            string[] route_point = line.Split(delimiterPoint);
            double lon = double.Parse(route_point[0]);
            double lat = double.Parse(route_point[1]);
            sb.Append(' ').Append(lon).Append(',').Append(lat);
            // coordinates.Add(new Vector(lat, lon));
        }
        writer.WriteValue(sb.ToString());
        writer.WriteEndElement(); // end coordinates
        writer.WriteEndElement(); // end LineString
        writer.WriteEndElement(); // end Placemark
        ...
