	private static double ArcInMeters(double lat0, double lon0, double lat1, double lon1)
	{
		double earthRadius = 6372797.560856; // m
		return earthRadius * ArcInRadians(lat0, lon0, lat1, lon1);
	}
    private static double ArcInRadians(double lat0, double lon0, double lat1, double lon1)
	{
		double latitudeArc = DegToRad(lat0 - lat1);
		double longitudeArc = DegToRad(lon0 - lon1);
		double latitudeH = Math.Sin(latitudeArc * 0.5);
		latitudeH *= latitudeH;
		double lontitudeH = Math.Sin(longitudeArc * 0.5);
		lontitudeH *= lontitudeH;
		double tmp = Math.Cos(DegToRad(lat0)) * Math.Cos(DegToRad(lat1));
		return 2.0 * Math.Asin(Math.Sqrt(latitudeH + tmp * lontitudeH));
	}
	private static double DegToRad(double x)
	{
		return x * Math.PI / 180;
	}
