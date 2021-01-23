    XElement xDoc = XElement.Parse(xml); //or XElement.Load(...)
    Rule rule = new Rule()
    {
        Name = (string)xDoc.Element("Name"),
        Parameters = String.Join("",xDoc.Element("Parameters").Elements())
    };
--
    class Rule
    {
        public string Name { get; set; }
        public string Parameters { get; set; }
    }
