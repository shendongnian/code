    public class CustomClass
        {
            public string id { get; set; }
            public int fileName { get; set; }
        }
    
    XDocument optXML = XDocument.Load(pathName);
    
    var optInput = (from item in optXML.Descendants("Group")
                        select new CustomClass()
                        {
                            id = (int)item.Attribute("ID"),
                            fileName = (string)item.Attribute("FileName")
                        }).ToList();
    foreach (CustomClass item in optInput)
            {
                Console.WriteLine(item.id);
            }
