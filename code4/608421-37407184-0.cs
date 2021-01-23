         /*Ready to use code :  simple copy paste GetLatLong*/
        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }
        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Northeast2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Southwest2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Viewport
        {
            public Northeast2 northeast { get; set; }
            public Southwest2 southwest { get; set; }
        }
        public class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }
        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }
        public class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
        public static RootObject GetLatLongByAddress(string address)
        {
            var root = new RootObject();
            var url =
                string.Format(
                    "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=true_or_false", address);
            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();
            using (var streamreader=new StreamReader(res.GetResponseStream()))
            {
                var result = streamreader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    root = JsonConvert.DeserializeObject<RootObject>(result);
                }
            }
            return root;
        }
              /* Call This*/
         
    var destination_latLong = GetLatLongByAddress(um.RouteDestination);
    var lattitude =Convert.ToString( destination_latLong.results[0].geometry.location.lat, CultureInfo.InvariantCulture);
     var longitude=Convert.ToString( destination_latLong.results[0].geometry.location.lng, CultureInfo.InvariantCulture);
