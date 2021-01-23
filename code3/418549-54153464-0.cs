            GMapOverlay markers = new GMapOverlay("markers");
            private void CreateCircle(Double lat, Double lon, double radius, int segments)
            {
                markers.Polygons.Clear();
                PointLatLng point = new PointLatLng(lat, lon);
    
                List<PointLatLng> gpollist = new List<PointLatLng>();
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, i, radius / 1000));
    
                List<PointLatLng> gpollistR = new List<PointLatLng>();
                List<PointLatLng> gpollistL = new List<PointLatLng>();
                foreach (var gp in gpollist)
                {
                    if (gp.Lng > lon)
                    {
                        gpollistR.Add(gp);
                    }
                    else
                    {
                        gpollistL.Add(gp);
                    }
                }
                gpollist.Clear();
    
                List<PointLatLng> gpollistRT = new List<PointLatLng>();
                List<PointLatLng> gpollistRB = new List<PointLatLng>();
                foreach (var gp in gpollistR)
                {
                    if (gp.Lat > lat)
                    {
                        gpollistRT.Add(gp);
                    }
                    else
                    {
                        gpollistRB.Add(gp);
                    }
                }
                gpollistRT.Sort(new LngComparer());
                gpollistRB.Sort(new Lng2Comparer());
                gpollistR.Clear();
                List<PointLatLng> gpollistLT = new List<PointLatLng>();
                List<PointLatLng> gpollistLB = new List<PointLatLng>();
                foreach (var gp in gpollistL)
                {
                    if (gp.Lat > lat)
                    {
                        gpollistLT.Add(gp);
                    }
                    else
                    {
                        gpollistLB.Add(gp);
                    }
                }
                //gpollistLT.Sort(new LngComparer());
                gpollistLB.Sort(new Lng2Comparer());
                gpollistLT.Sort(new LngComparer());
                gpollistL.Clear();
    
    
                gpollist.AddRange(gpollistRT);
                gpollist.AddRange(gpollistRB);
                gpollist.AddRange(gpollistLB);
                gpollist.AddRange(gpollistLT);
                GMapPolygon gpol = new GMapPolygon(gpollist, "pol");
                gpol.Stroke = new Pen(Color.Red, 1);
                markers.Polygons.Add(gpol);
            }
    
            public static GMap.NET.PointLatLng FindPointAtDistanceFrom(GMap.NET.PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
            {
                const double radiusEarthKilometres = 6371.01;
                var distRatio = distanceKilometres / radiusEarthKilometres;
                var distRatioSine = Math.Sin(distRatio);
                var distRatioCosine = Math.Cos(distRatio);
    
                var startLatRad = DegreesToRadians(startPoint.Lat);
                var startLonRad = DegreesToRadians(startPoint.Lng);
    
                var startLatCos = Math.Cos(startLatRad);
                var startLatSin = Math.Sin(startLatRad);
    
                var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
    
                var endLonRads = startLonRad + Math.Atan2(
                              Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                              distRatioCosine - startLatSin * Math.Sin(endLatRads));
    
                return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
            }
    
            public static double DegreesToRadians(double degrees)
            {
                const double degToRadFactor = Math.PI / 180;
                return degrees * degToRadFactor;
            }
    
            public static double RadiansToDegrees(double radians)
            {
                const double radToDegFactor = 180 / Math.PI;
                return radians * radToDegFactor;
            }
