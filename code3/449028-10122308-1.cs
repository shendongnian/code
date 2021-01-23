    static class MovieExtension
	{
		public static List<string> ImagesAsList(this Movie m)
		{
			var jArray = (m.Images as JArray);
			if (jArray == null) return null;
			return jArray.Select(x => x.ToString()).ToList();
		}
		public static string ImagesAsString(this Movie m)
		{
			return m.Images as string;
		}
	}
