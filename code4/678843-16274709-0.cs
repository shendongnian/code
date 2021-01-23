    /// <summary>
    /// returns latitude 
    /// </summary>
    /// <param name="addresspoint"></param>
    /// <returns></returns>
    public double GetCoordinatesLat(string addresspoint)
    {
        using (var client = new WebClient())
        {
            string seachurl = "http://maps.google.com/maps/geo?q='" + addresspoint + "'&output=csv";
            string[] geocodeInfo = client.DownloadString(seachurl).Split(',');
            return (Convert.ToDouble(geocodeInfo[2]));
        }
    }
    
    /// <summary>
    /// returns longitude 
    /// </summary>
    /// <param name="addresspoint"></param>
    /// <returns></returns>
    public double GetCoordinatesLng(string addresspoint)
    {
        using (var client = new WebClient())
        {
            string seachurl = "http://maps.google.com/maps/geo?q='" + addresspoint + "'&output=csv";
            string[] geocodeInfo = client.DownloadString(seachurl).Split(',');
            return (Convert.ToDouble(geocodeInfo[3]));
        }
    }  
