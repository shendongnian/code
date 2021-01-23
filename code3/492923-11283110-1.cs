    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    [XmlRoot("result")]
    public class VehicleDetails
    {
        public string Type { get; set; }
        public string Make { get; set; }
        public Country Country { get; set; }
    }
    
    public class Country
    {
        [XmlText]
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(VehicleDetails));
            var xml = 
            @"<result>
                <Type>MAZDA</Type>
                <Make>RX-8</Make>
                <Country>JAPAN</Country>
            </result>";
            using (var reader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(reader))
            {
                var result = (VehicleDetails)serializer.Deserialize(xmlReader);
                Console.WriteLine(result.Country.Name);
            }
        }
    }
