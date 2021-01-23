    double lat1 = FSConvert.DegreesToRadians(start.Latitude.Decimal);
                            double lon1 = FSConvert.DegreesToRadians(start.Longitude.Decimal) * -1;
                            double d = FSConvert.MetersToDrad(distance);
                            double tc = FSConvert.DegreesToRadians(bearing);
    
                            double lat = Math.Asin(Math.Sin(lat1) * Math.Cos(d) + Math.Cos(lat1) * Math.Sin(d) * Math.Cos(tc));
                            double lon = ((lon1 - Math.Asin(Math.Sin(tc) * Math.Sin(d) / Math.Cos(lat)) + Math.PI) % (2 * Math.PI)) - Math.PI;
    
                            var returnPoint = new FSPoint {
                                Latitude = {
                                    Decimal = FSConvert.RadiansToDegrees(lat)
                                },
                                Longitude = {
                                    Decimal = FSConvert.RadiansToDegrees(lon) * -1
                                }
                            };
                            point = returnPoint;
