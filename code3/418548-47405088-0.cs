       private void CreateCircle(Double lat, Double lon, double radius, int ColorIndex)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            int segments = 1080;
            List<PointLatLng> gpollist = new List<PointLatLng>();
            for (int i = 0; i < segments; i++)
            {
                gpollist.Add(FindPointAtDistanceFrom(point, i*(Math.PI/180), radius / 1000));
            }
            
            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle");
            switch (ColorIndex) {
                case 1:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Red));
                    break;
                case 2:
                    polygon.Fill = new SolidBrush(Color.FromArgb(80, Color.Orange));
                    break;
                case 3:
                    polygon.Fill = new SolidBrush(Color.FromArgb(20, Color.Aqua));
                    break;
                default:
                    MessageBox.Show("No search zone found!");
                    break;
            }
            
                        
            polygon.Stroke = new Pen(Color.Red, 1);
            markers.Polygons.Add(polygon);
            gMapCtl.Overlays.Add(markers);
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
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,distRatioCosine - startLatSin * Math.Sin(endLatRads));
            return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }
        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI/180;
            return degrees * degToRadFactor;
        }
        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180/Math.PI;
            return radians * radToDegFactor;
        }
        public static double DistanceTwoPoint(double startLat, double startLong, double endLat, double endLong) {
            var startPoint = new GeoCoordinate(startLat, startLong);
            var endPoint = new GeoCoordinate(endLat, endLong);
            return startPoint.GetDistanceTo(endPoint);
        }
