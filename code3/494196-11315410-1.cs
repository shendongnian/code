	public static double GetDistance(double lat1, double long1, double lat2, double long2)
	{
		GeoCoordinate geo1 = new GeoCoordinate(lat1, long1);
		GeoCoordinate geo2 = new GeoCoordinate(lat2, long2);
		return geo1.GetDistanceTo(geo2);
	}
