    public class Folder
	{
		public Folder(Dictionary<string, object> newFolder)
		{
			if (newFolder.ContainsKey("dir"))
			{
				Directory = (string)newFolder["dir"];
			}
			if (newFolder.ContainsKey("dirToCreate"))
			{
				DirectoryToCreate = (string)newFolder["dirToCreate"];
			}
		}
		public string Directory { get; set; }
		public string DirectoryToCreate { get; set; }
	}
