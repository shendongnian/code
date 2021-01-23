    static void Main(string[] args)
    {
       using(var writer = new XmlTextWriter("Maps.xml", System.Text.Encoding.UTF8))
       {
         String[] filenames = Directory.GetFiles(@"maps_new");
         writer.WriteStartDocument();
         writer.WriteStartElement("Maps");
         foreach (String file in filenames)
         {
            extractToXML(file, writer);
         }
         writer.WriteEndElement();    
         writer.WriteEndDocument();
         writer.Flush();
         writer.Close();
       }
    }
    public static void extractToXML(String filename, XmlTextWriter wirter)
    {
        XPathNodeIterator NodeIter;
        XPathDocument xmldoc = new XPathDocument(filename);
        XPathNavigator nav = xmldoc.CreateNavigator();
        String query = "//Schema/@tree";
        NodeIter = nav.Select(query);
        writer.WriteStartElement("file");
        writer.WriteStartAttribute("name");
        writer.WriteString(extractFileName(filename));
        writer.WriteEndAttribute();
        while (NodeIter.MoveNext())
        {
            writer.WriteStartElement("type");
            writer.WriteString(extractFileName(NodeIter.Current.Value.ToString()));
            writer.WriteEndElement();            
        }
        NodeIter = nav.Select("//Location");
        while (NodeIter.MoveNext())
        {
            writer.WriteStartElement("Location");
            writer.WriteString(NodeIter.Current.Value.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();
    }
