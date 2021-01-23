    private static Double rad2deg(Double rad) {
    	return (rad / Math.PI * 180.0);
    }
    
    private static Double deg2rad(Double deg) {
    	return (deg * Math.PI / 180.0);
    }
    
    private const Double kEarthRadiusKms = 6376.5;
    
    private static Double CalculateDistance(Double latitude1, Double longitude1, Double latitude2, Double longitude2) {
    	double theta = longitude1 - longitude2;
    	double dist = Math.Sin(deg2rad(latitude1)) * Math.Sin(deg2rad(latitude2)) + Math.Cos(deg2rad(latitude1)) * Math.Cos(deg2rad(latitude2)) * Math.Cos(deg2rad(theta));
    	dist = Math.Acos(dist);
    	dist = rad2deg(dist);
    	dist = dist * 60 * 1.1515;
    	dist = dist * 1.609344;
    	return (dist);
    }
