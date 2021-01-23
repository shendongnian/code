	public static string GetUniqueFilePath(string filepath)
	{
		if (File.Exists(filepath))
		{
			string folder = Path.GetDirectoryName(filepath);
			string filename = Path.GetFileNameWithoutExtension(filepath);
			string extension = Path.GetExtension(filepath);
			int number = 1;
			Match regex = Regex.Match(filepath, @"(.+) \((\d+)\)\.\w+");
			if (regex.Success)
			{
				filename = regex.Groups[1].Value;
				number = int.Parse(regex.Groups[2].Value);
			}
			do
			{
				number++;
				filepath = Path.Combine(folder, string.Format("{0} ({1}){2}", filename, number, extension));
			}
			while (File.Exists(filepath));
		}
		return filepath;
	}
