    public class StackOverflow_12924221
    {
        [XmlRoot("scan_details")]
        public class ScanDetails
        {
            [XmlElement("object")]
            public ScanDetail[] Items { get; set; }
        }
        public class ScanDetail
        {
            [XmlAttribute("name")]
            public string Filename { get; set; }
        }
        const string XML = @"<scan_details> 
                                <object name=""C:\Users\MyUser\Documents\Target1.doc""> 
                                </object> 
                                <object name=""C:\Users\MyUser\Documents\Target2.doc""> 
                                </object> 
                            </scan_details> ";
        public static void Test()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ScanDetails));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
            var obj = xs.Deserialize(ms) as ScanDetails;
            foreach (var sd in obj.Items)
            {
                Console.WriteLine(sd.Filename);
            }
        }
    }
