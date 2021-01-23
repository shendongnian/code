    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Shortcut
    {
        public List<Property> Properties = new List<Property>();
    }
    class Program
    {
        static Dictionary<string, Shortcut> ShortcutDictionary = new Dictionary<string, Shortcut>();
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"c:\temp\example.xml", FileMode.Open, FileAccess.Read);
            XmlTextReader reader = new XmlTextReader(fs);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "shortcuts")
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "shortcut")
                        {
                            Shortcut shortcut = new Shortcut();
                            ShortcutDictionary.Add(reader.GetAttribute("name"), shortcut);
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "property")
                                    shortcut.Properties.Add(new Property() { Name = reader.GetAttribute("name"), Value = reader.GetAttribute("value") });
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "shortcut")
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "shortcuts")
                            break;
                    }
                }
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "data")
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "datum")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "property")
                                {
                                    Console.WriteLine(reader.GetAttribute("name") + ':' + reader.GetAttribute("value"));
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "shortcutRef")
                                {
                                    foreach (Property property in ShortcutDictionary[reader.GetAttribute("name")].Properties)
                                        Console.WriteLine(property.Name + ':' + property.Value);
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "datum")
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "data")
                            break;
                    }
                }
            }
            reader.Close();
            fs.Close();
        }
    }
