    public class Factory
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Interval { get; set; }
        //Create a factory
        public Factory(XElement xFactory)
        {
            Name = xFactory.Attribute("Name").Value;
            Url = xFactory.Attribute("Url").Value;
            Thumbnail = xFactory.Attribute("Thumbnail").Value;
            Interval = xFactory.Attribute("Interval").Value;
        }
        //Get the factories of a version
        public static List<Factory> GetFactories(XElement xVersion)
        {
            var xFactories = xVersion.Elements("Factory");
            if (xFactories == null)
                return null;
            List<Factory> list = new List<Factory>();
            foreach (var xFactory in xFactories)
            {
                list.Add(new Factory(xFactory));
            }
            return list;
        }
    }
