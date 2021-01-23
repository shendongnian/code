    public static Coordinate GetCoordinates(string region)
    {
        using (var client = new WebClient())
        {
    
            string uri = "http://maps.google.com/maps/geo?q='" + region + 
              "'&output=csv&key=sadfwet56346tyeryhretu6434tertertreyeryeryE1";
    
            string[] geocodeInfo = client.DownloadString(uri).Split(',');
    
            return new Coordinate(Convert.ToDouble(geocodeInfo[2]), 
                       Convert.ToDouble(geocodeInfo[3]));
        }
    }
    
    public struct Coordinate
    {
        private double lat;
        private double lng;
    
        public Coordinate(double latitude, double longitude)
        {
            lat = latitude;
            lng = longitude;
    
        }
    
        public double Latitude { get { return lat; } set { lat = value; } }
        public double Longitude { get { return lng; } set { lng = value; } }
    
    }
