    class Testtypes
    {
        public string Type;
    
        public static List<Testtypes> getTypes()
        {
            var doc = XDocument.Load("test.xml");
            return doc.Root.Elements("Type")
                       .Select(x => new Testtypes
                       {
                           Type = x.Value
                       }
                       .ToList();
        }
    }
