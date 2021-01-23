            var doc = XDocument.Load("settings.xml");
            var result = from items in doc.Descendants("StartItems")
                         where items.Parent.Attribute("CompanyID").Value == "1"
                         select new StartItem() 
                                    {
                                        StartID = items.Attribute("StartID").Value,
                                        Value = items.Value
                                    };
            var Company1List = new ArrayList();
            
            foreach(var item in result)
            {
                Company1List.Add(item);
            }
    public class StartItem
    {
        public string StartID{ get; set;}
        public string Value { get; set;}
    }
