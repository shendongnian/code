    using System.Xml.Serialization;
    namespace MyNs.Model
    {
    	[XmlRoot("Tips")]
    	public partial class Tips
    	{
    		[XmlElement("Chapter")]
    		public Chapter[] Chapter { get; set; }
    	}
    
    	[XmlRoot("Chapter")]
    	public partial class Chapter
    	{
    		[XmlElement("Heading")]
    		public string Heading { get; set; }
    
    		[XmlElement("CarType")]
    		public CarType[] CarTypes { get; set; }
    
    		[XmlElement("Section")]
    		public Section[] Section { get; set; }
    
    		[XmlAttribute("Country")]
    		public string Country { get; set; }
    
    		[XmlAttribute("Language")]
    		public string Language { get; set; }
    	}
        [... and so on ...]
