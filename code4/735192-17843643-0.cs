    // ************************************************************************
    // If someday Microsoft make Color serializable ...
		//public static void SaveColors(Color[] colors, string path)
		//{
		//	BinaryFormatter bf = new BinaryFormatter();
		//	MemoryStream ms = new MemoryStream();
		//	bf.Serialize(ms, colors);
		//	byte[] bytes = ms.ToArray();
		//	File.WriteAllBytes(path, bytes);
		//}
    // If someday Microsoft make Color serializable ...
		//public static Colors[] LoadColors(string path)
		//{
		//	Byte[] bytes = File.ReadAllBytes(path);
		//	BinaryFormatter bf = new BinaryFormatter();
		//	MemoryStream ms2 = new MemoryStream(bytes);
		//	return (Colors[])bf.Deserialize(ms2);
		//}
		// ******************************************************************
		public static void SaveColorsToFile(Color[] colors, string path)
		{
			var formatter = new BinaryFormatter();
			int count = colors.Length;
			using (var stream = File.OpenWrite(path))
			{
				formatter.Serialize(stream, count);
				for (int index = 0; index < count; index++)
				{
					formatter.Serialize(stream, colors[index].R);
					formatter.Serialize(stream, colors[index].G);
					formatter.Serialize(stream, colors[index].B);
				}
			}
		}
		// ******************************************************************
		public static Color[] LoadColorsFromFile(string path)
		{
			var formatter = new BinaryFormatter();
			Color[] colors;
			using (var stream = File.OpenRead(path))
			{
				int count = (int)formatter.Deserialize(stream);
				colors = new Color[count];
				for (int index = 0; index < count; index++)
				{
					byte r = (byte)formatter.Deserialize(stream);
					byte g = (byte)formatter.Deserialize(stream);
					byte b = (byte)formatter.Deserialize(stream);
					colors[index] = Color.FromRgb(r, g, b);
				}
			}
			
			return colors;
		}
		// ******************************************************************
