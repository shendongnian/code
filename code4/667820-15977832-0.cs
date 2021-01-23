	public class ImageEx
	{
		public Image Image { get; set; }
		public string Filename { get; set; }
		public ImageEx(string filename)
		{
			this.Image = Image.FromFile(filename);
			this.Filename = filename;
		}
	}
	public class SomeClass
	{
		public void SomeMethod()
		{
			ImageEx img = new ImageEx(@"C:\1.jpg");
			Debug.WriteLine("Loaded file: {0}", img.Filename);
			Debug.WriteLine("Dimensions: {0}x{1}", img.Image.Width, img.Image.Height);
		}
	}
