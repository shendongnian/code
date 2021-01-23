    List<GeoCoordinate> listTakenFromXml = ......
    double lat = ......
    double lon = ........
    var nereast = new GeoCoordinate(lat, lon).NearestPoint(listTakenFromXml);
---
    public static class SoExtensions
    {
        public static GeoCoordinate NearestPoint(this GeoCoordinate loc, IEnumerable<GeoCoordinate> coords)
        {
            GeoCoordinate minLoc = null;
            double minDist = double.MaxValue;
            foreach (var c in coords)
            {
                var dist = c.GetDistanceTo(loc);
                if ( dist < minDist)
                {
                    minDist = dist;
                    minLoc = c;
                }
            }
            return minLoc;
        }
    }
