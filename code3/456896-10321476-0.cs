    public class MainClass
    {
        public static void Main(string[] args)
        {
            var response = new FileStream("Response.xml", FileMode.Open);
            XDocument doc = XDocument.Load(response);
            XNamespace xmlns = "http://getlocations.ws.hymedis.net";
            var nodes = doc.Descendants(xmlns + "locs")
                                .Elements(xmlns + "loc");
            var list = new List<Location>();
            foreach (var node in nodes)
            {
                list.Add(new Location {
                    Name = node.Element(xmlns + "name").Value,
                    Code = node.Element(xmlns + "abbr").Value
                });
            }
            foreach (var item in list) {
                Console.WriteLine(item.Code);
            }
        }
        public class Location 
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
