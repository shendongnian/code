	public class PhotoList : DataSourceProvider
	{
		protected override void BeginQuery()
		{
			var files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
							.Where(f => Path.GetExtension(f) == ".png")
			OnQueryFinished(files);
		}
	}
