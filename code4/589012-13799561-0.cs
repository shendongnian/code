	public class WindowSize
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}
	public static class WindowSizeStorage
	{
		public static string savePath = "WindowSize.dat";
		public static WindowSize ReadSettings()
		{	
			var result = new WindowSize();
			
			using (BinaryReader binaryReader = new BinaryReader(new StreamReader(savePath)))
			{
				result.Width = binaryReader.ReadInt32();
				result.Height = binaryReader.ReadInt32();
			}
			
			return result;
		}
		
		public static void WriteSettings(WindowSize toSave)
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(savePath, FileMode.Create)))
			{
				binaryWriter.Write(toSave.Width);
				binaryWriter.Write(toSave.Height);
			}
		}
	}
