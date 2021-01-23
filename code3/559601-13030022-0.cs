    [XmlRoot]
    public class body
    {
    	[XmlElement]
    	public h1 h1 { get; set; }
    
    	[XmlElement]
        public p p { get; set; }
    }
    
    public class h1 
    {
    	[XmlText]
    	public string innerXML { get; set; }
    }
    
    public class p 
    {
        [XmlAttribute]
    	public string id { get; set; }
    	
    	[XmlText]
    	public string innerXML { get; set; }
    }
