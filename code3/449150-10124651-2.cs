    StringBuilder sb = new StringBuilder();
	foreach (KeyValuePair<DirectoryInfo, List<FileInfo>> item in GetTopFolders())
	{
		sb.AppendLine(item.Key.FullName);
		foreach (FileInfo file in item.Value)
		{
			sb.AppendLine("\t" + file.Name);
		}
	}
	Console.WriteLine(sb.ToString());
