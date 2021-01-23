	[XmlRoot("images")]
	public class ImageListWrapper
	{
		public ImageListWrapper()
		{
			Images = new List<Image>(); 
		}
		
		[XmlElement("image")]
		public List<Image> Images
		{
			get; set;
		}
	}
	
	[XmlRoot("image")]
	public class Image
	{
		[XmlAttribute("href")]
		public string Href { get; set; }
	}
