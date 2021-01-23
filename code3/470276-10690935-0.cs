    public class GeoNames
    {
        [XmlElement("country")]
        public Country[] Countries { get; set; }
    }
    
    public class Country
    {
        [XmlElement("countryName")]
        public string CountryName { get; set; }
    
        [XmlElement("countryCode")]
        public string CountryCode { get; set; }
    } 
    
    class Program
    {
        static void Main()
        {
            var url = "http://ws.geonames.org/countryInfo?lang=it&country=DE";
            var serializer = new XmlSerializer(typeof(GeoNames), new XmlRootAttribute("geonames"));
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            {
                var geoNames = (GeoNames)serializer.Deserialize(stream);
                foreach (var country in geoNames.Countries)
                {
                    Console.WriteLine(
                        "code: {0}, name: {1}", 
                        country.CountryCode, 
                        country.CountryName
                    );
                }
            }
        }
    }
