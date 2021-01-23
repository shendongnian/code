    public class Version
    {
        public bool IsProduct { get; set; }
        public string City { get; set; }
        public List<Factory> Factories { get; set; }
        //Create a version
        public Version(XElement xVersion)
        {
            IsProduct = Convert.ToBoolean(xVersion.Element("Product").Value);
            City = xVersion.Element("City").Value;
            Factories = Factory.GetFactories(xVersion);
        }
        //Get the list of versions
        public static List<Version> GetVersions(XElement xDocument)
        {
            if (xDocument == null)
                return null;
            List<Version> list = new List<Version>();
            var xVersions = xDocument.Elements("Version");
            foreach (var xVersion in xVersions)
            {
                list.Add(new Version(xVersion));
            }
            return list;
        }
    }
