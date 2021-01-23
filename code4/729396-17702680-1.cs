    static void Main(string[] args)
            {
                XDocument xd = CreateXml();
                List<string> stuff = GeneratList();
                PopulateArray(stuff, xd);
            }
    
            private static XDocument PopulateArray(List<string>mylist, XDocument xmlFile)
            {
                var row = xmlFile.Descendants("tablerow");
    
                foreach (var r in row)
                {
                    var i = 0;
                    var cell = r.Descendants("cell");
                    foreach (var c in cell)
                    {
                        c.Add(new XText(mylist[i++]));
                    }
                }
                return xmlFile;
            }
    
            private static XDocument CreateXml()
            {
                XDocument doc = new XDocument(
                    new XElement("table",
                        new XElement("tablerow",
                            new XElement("cell"),
                            new XElement("cell"),
                            new XElement("cell")
                        ),
                    new XElement("tablerow",
                            new XElement("cell"),
                            new XElement("cell"),
                            new XElement("cell")
                        )           
                    )     
                    );
                return doc;
            }
    
            private static List<string> GenerateList()
            {
                return new List<string> {
                    "Orange",
                    "Grape",
                    "Banana"
                };
            }
