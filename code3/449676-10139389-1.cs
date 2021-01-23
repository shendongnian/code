    [XmlRoot("docRoot")]
    public class DocRoot
    {
      [XmlElement("doc-sets")]
      public List<DocSet> DocSets;
    }
    public class DocSet
    {
      [XmlElement("docs")]
      public List<Doc> Docs;
    }
    public class Doc
    {
      [XmlElement("link", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2005/Atom")]
      public List<Link> Links;
    }
    public class Link
    {
      [XmlAttribute("href")]
      public string Href;        
    }
