    XDocument doc = XDocument.Load(@"E:\a\b.xml");
            List<Area> result = new List<Area>();
            foreach (var item in doc.Elements("Area"))
            {
                var tmp = new Area();
                tmp.Name = item.Attribute("Name").Value;
                tmp.IntegrationID = int.Parse(item.Attribute("IntegrationID").Value);
                tmp.OccupancyGroupAssignedToID = int.Parse(item.Attribute("OccupancyGroupAssignedToID").Value);
                foreach (var bitem in item.Elements("Outputs"))
                {
                    foreach (var citem in bitem.Elements("Output"))
                    {
                        tmp.Outputs.Add(new Output
                        {
                            IntegrationID = int.Parse(citem.Attribute("IntegrationID").Value),
                            Name = citem.Attribute("Name").Value,
                            OutputType = citem.Attribute("OutputType").Value,
                            Wattage = int.Parse(citem.Attribute("Wattage").Value)
                        });
                    }
                }
                result.Add(tmp);
            }
    public class Area
    {
        public String Name { get; set; }
        public int IntegrationID { get; set; }
        public int OccupancyGroupAssignedToID { get; set; }
        public List<Output> Outputs = new List<Output>();
    }
    public class Output
    {
        public String Name { get; set; }
        public int IntegrationID { get; set; }
        public String OutputType { get; set; }
        public int Wattage { get; set; }
    }
