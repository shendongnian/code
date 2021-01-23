    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication2
    {
        public class Program
        {
            [XmlType("price")]
            public class Price
            {
                [XmlText]
                public double price { get; set; }
    
                [XmlAttribute("fuel")]
                public string fuel { get; set; }
            }
    
            [XmlType("prices")]
            public class PriceList : List<Price>
            {
                 
            }
    
            static void Main(string[] args)
            {
                //Serialize
                var plist = new PriceList()
                    {
                        new Price {price = 153.9, fuel = "Diesel"},
                        new Price {price = 120.6, fuel = "Petrol"}
                    };
                var serializer = new XmlSerializer(typeof(PriceList));
                var sw = new StringWriter();
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
    
                serializer.Serialize(sw, plist, ns);
                var result = sw.ToString();//result xml as we like
    
                //Deserialize
    
                var sr = new StringReader(result);
                var templist = (PriceList)serializer.Deserialize(sr);
                var myDictionary = templist.ToDictionary(item => item.fuel, item => item.price);
            }
        }
    }
