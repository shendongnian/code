        public void KmlExport()
        {
            string cellColor = "COLOR";
            string KMLname = "KML NAME";
            string description = "KML DESCRIPTION";
            string kml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                            <kml xmlns=""http://www.opengis.net/kml/2.2"">
                                <Document>
                                    <Style id=""polygon"">
                                        <LineStyle>
                                            <color>FF" + cellColor + @"</color>
                                        </LineStyle>
                                        <PolyStyle>
                                            <color>44" + cellColor + @"</color>
                                            <fill>1</fill>
                                            <outline>1</outline>
                                        </PolyStyle> 
                                    </Style>
                                    <name>" + KMLname + @"</name>
                                    <description>" + description + "</description>";
            SqlCommand cmd = new SqlCommand("Select Statement", connectionString);
            cs.Open();
            SqlDataReader polygon = cmd.ExecuteReader();
            while (polygon.Read())
            {
                string kmlCoordinates = string.Empty;
                SqlGeography geo = (SqlGeography)polygon["GEOGRAPHY COLUMN"];
                    for (int i = 1; i <= geo.STNumPoints(); i++)
                    {
                        SqlGeography point = geo.STPointN(i);
                        kmlCoordinates += point.Long + "," + point.Lat + " ";
                    }
                    string polyName = polygon["Name Column"].ToString();
                    string polyDescription = polygon["Description Column"].ToString();
                    kml += @"
                    <Placemark>
                        <name>" + polyName + @"</name>
                        <description><![CDATA[<p>" + polyDescription + "</p>]]></description>" +
                            @"<styleUrl>#polygon</styleUrl>
                        <Polygon>
                            <extrude>1</extrude>
                            <altitudeMode>clampToSeaFloor</altitudeMode>
                            <outerBoundaryIs>
                                <LinearRing>
                                    <coordinates>" + kmlCoordinates +
                                  @"</coordinates>
                                </LinearRing>
                            </outerBoundaryIs>
                        </Polygon>
                    </Placemark>";
                    kmlCoordinates = string.Empty;
                }
            cs.Close();
            kml += @"</Document></kml>";
            StreamWriter file = new StreamWriter(@"OUTPUTFILE.KML");
            file.WriteLine(kml);
            file.Close();
