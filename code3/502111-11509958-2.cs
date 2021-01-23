    XDocument xDoc = XDocument.Load("http://api.serviceu.com/rest/events/occurrences?orgkey=613dc2ce-0b32-4926-8e7e-33ee279be1cb");
    var list = xDoc.Descendants("Occurrence")
                .Select(o => new Item
                {
                    Category = (string)o.Element("CategoryList"),
                    EMail = (string)o.Element("ContactEmail"),
                    Description = (string)o.Element("Description"),
                })
                .ToList();
    public class Item
    {
        public string Category;
        public string EMail;
        public string Description;
    }
