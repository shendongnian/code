    [XmlRoot("docRoot")]
    public class DocRoot
    {
      [XmlElement("doc-sets")]
      public List<DocSets> docSets;
    }
    public class DocSets
    {
      [XmlElement("docs")]
      public List<Docs> docs;
    }
    public class Docs
    {
      [XmlElement("link", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2005/Atom")]
      public List<Link> Links;
    }
    public class Link
    {
      [XmlAttribute("href")]
      public string Href;        
    }
