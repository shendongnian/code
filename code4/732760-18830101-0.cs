    using Microsoft.SqlServer.Types;
    using System.Data.SqlClient;
        GMap.NET.WindowsForms.GMapOverlay o = new GMapOverlay();
        GMap.NET.WindowsForms.GMapOverlay o1 = new GMapOverlay();
        List<PointLatLng> p = new List<PointLatLng>();
        List<string> p1 = new List<string>();
    //below adds a marker to the map upon each users click. At the same time adding that Lat/Long to a <PointLatLng> list
        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                p.Add(new PointLatLng(Convert.ToDouble(gMapControl2.FromLocalToLatLng(e.X, e.Y).Lat), Convert.ToDouble(gMapControl2.FromLocalToLatLng(e.X, e.Y).Lng)));
                p1.Add(gMapControl2.FromLocalToLatLng(e.X, e.Y).Lng + " " + gMapControl2.FromLocalToLatLng(e.X, e.Y).Lat);
                GMarkerGoogle marker = new GMarkerGoogle(gMapControl2.FromLocalToLatLng(e.X, e.Y), GMarkerGoogleType.red_small);
               // marker.Tag =(gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng + " " + gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat);
                
                o.Markers.Add(marker);
                gMapControl2.Overlays.Add(o);
            }
        }
    //Then the below code will add that <PointLatLng> List to a SQL query and return Area and Centoid of polygon. Area is returned in Acres
     private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    o.Clear();
                    n = new GMapPolygon(p, "polygon");
                    n.Fill = new SolidBrush(Color.Transparent);
                    n.Stroke = new Pen(Color.Red, 1);
                    o.Polygons.Add(n);
                    gMapControl2.Overlays.Add(o);
                    StringBuilder a = new StringBuilder();
                    StringBuilder b = new StringBuilder();
                    p1.ToArray();
                    for (int i = 0; i != p1.Count; i++)
                    {
                        a.Append(p1[i].ToString() + ",");
                    }
                    a.Append(p1[0].ToString());
                    cs.Open();
                    SqlCommand cmd = new SqlCommand("Declare @g geography; set @g = 'Polygon((" + a + "))'; Select Round((@g.STArea() *0.00024711),3) As Area", cs);
                    SqlCommand cmd1 = new SqlCommand("Declare @c geometry; set @c =geometry::STGeomFromText('Polygon((" + a + "))',0);  Select Replace(Replace(@c.STCentroid().ToString(),'POINT (',''),')','')AS Center", cs);
                    poly = "Polygon((" + a + "))";
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtArea.Text = sdr["Area"].ToString();
                    }
                    sdr.Close();
                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                    while (sdr1.Read())
                    {
                        center = sdr1["Center"].ToString();
                        lat = center.Substring(center.IndexOf(" ") + 1);
                        lat = lat.Remove(9);
                        lon = center.Substring(0, (center.IndexOf(" ")));
                        lon = lon.Remove(10);
                        txtCenter.Text = lat + ", " + lon;
                    }
                    sdr1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please start the polygon over, you must create polygon in a counter-clockwise fasion","Counter-Clockwise Only!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    p.Clear();
                    p1.Clear();
                    cs.Close();
                    o.Markers.Clear();
                }
            }
        }
