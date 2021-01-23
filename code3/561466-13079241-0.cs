    public class MyXMLNamesReader
    {
        public static List<string> readNames(string path)
        {
            List<string> names = new List<string>();
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement element in xDoc.Descendants("Name"))
            {
                names.Add(element.Value);
                
            }
            return names;
        }
    
    }
