    [XmlRoot(ElementName="item")]
    public class RssNews
    {
    	[XmlElement(ElementName = "title")]
    	public string Title { get; set; }
    
    	[XmlElement(ElementName = "pubDate")]
    	public string PublicationDate  { get; set; }
    
    	[XmlElement(ElementName = "description")]
    	public string Description { get; set; }
    
    	[XmlElement(ElementName = "link")]
    	public string Link { get; set; }
    
    	[XmlElement(ElementName = "guid")]
    	public string Description { get; set; }
    }
