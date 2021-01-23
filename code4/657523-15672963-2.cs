    public async Task ReturnClosestCurrent(string address)
    {
        await convertAddressToCoordinate(address)
                .ContinueWith(t => compareDistance(t.Result));
    }
    public async Task<GeoCoordinate> ConvertAddressToCoordinate(string add)
    {
        WebClient wc = new WebClient();
        wc.DownloadStringCompleted += wc_DownloadStringCompleted;
        var content = await wc.DownloadStringTaskAsync(new Uri("http://maps.googleapis.com/maps/api/geocode/json?address=1600+bay+st&sensor=false"));
        return ParseContent(content);
    }
     
    private GeoCoordinate ParseContent(string content)
    {
        XDocument xdoc = XDocument.Parse(content, LoadOptions.None);
        var data = from query in xdoc.Descendants("location")
                 select new Location
                 {
                     lat = (string)query.Element("lat"),
                     lng = (string)query.Element("lng")
                 };
        GeoCoordinate destinationGeo = new GeoCoordinate(Convert.ToDouble(data.ElementAt(0).lat), Convert.ToDouble(data.ElementAt(0).lng));
        return destinationGeo;
    }
