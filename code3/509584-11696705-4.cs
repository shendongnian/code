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
		public List<string> GetImageLocations()
		{
			List<string> imageLocations = new List<string>();
			foreach (Image image in Images)
			{
				imageLocations.Add(image.Href);
			}
			return imageLocations;
		}
	}
	
	[XmlRoot("image")]
	public class Image
	{
		[XmlAttribute("href")]
		public string Href { get; set; }
	}
