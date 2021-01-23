    public class StoryImage
    {
    	[XmlElement("img")]
    	public Image Img { get; set; }
    }
    
    public class Image
    {
    	[XmlAttribute("src")]
    	public string Source { get; set; }
    }
    
    [Serializable]
    [XmlRoot("entry", Namespace = "http://www.w3.org/2005/Atom")]
    public class NewsItem
    {
    	[XmlElement("fullstoryimage")]
    	public StoryImage FullStoryImage { get; set; }
    }
