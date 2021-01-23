    public class Response
    {
        public string Ip { get; set; }
        public string Countrycode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MetroCode { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var client = new System.Net.WebClient();
            string downloadedString = client.DownloadString("http://freegeoip.net/xml/123.123.123.123");
            
            XmlSerializer mySerializer =
                new XmlSerializer(typeof(Response));
            Response response = null;
            XmlReader xmlReader = XmlReader.Create(new System.IO.StringReader(downloadedString));
            response = (Response)mySerializer.Deserialize(xmlReader);
            
        }
    }
