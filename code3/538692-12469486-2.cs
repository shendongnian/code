    public class ArtistData
	{
		public List<string> Artists{ get; set; }
		public ArtistData()
		{
			this.Artists = new List<string>(0);
		}
		public void PopulateArtists(string jsonFeed)
		{
			// here something desrializes your JSON, allowing you to extract the artists...
			// here you would be populating the Artists property by adding them to the list in a loop...
		}
	}
 
