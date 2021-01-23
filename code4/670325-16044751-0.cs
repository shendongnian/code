    var airports1 = Airports.Search(51, 0, 100).ToList(); //~London
    var airports2 = Airports.Search(40.714623, -74.006605,100).ToList(); //~NY
---
    public class Airports
    {
        public class Airport
        {
            public string Name;
            public GeoCoordinate Location;
            public override string ToString()
            {
                return Name;
            }
        }
        static Lazy<List<Airport>> _Airports = new Lazy<List<Airport>>(() =>
            {
                using (var wc = new WebClient())
                {
                    var json = wc.DownloadString("http://www.flightradar24.com/AirportDataService2.php");
                    var jObj = new JavaScriptSerializer().Deserialize<Dictionary<string,string[]>>(json);
                    
                    return jObj.Values
                               .Select(j => new Airport
                                {
                                    Name = (string)j[2],
                                    Location = new GeoCoordinate(double.Parse(j[3].ToString(), CultureInfo.InvariantCulture),double.Parse(j[4].ToString(), CultureInfo.InvariantCulture))
                                })
                                .ToList();
                }
            }, true);
        public static IEnumerable<Airport> Search(double lat,double lon, double distInMiles)
        {
            var loc = new GeoCoordinate(lat, lon);
            return _Airports.Value.Where(c => c.Location.GetDistanceTo(loc) < distInMiles * 1609.344);
        }
    }
