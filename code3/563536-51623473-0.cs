    IEnumerator<string> errFiles=Directory.EnumerateFiles(baseDir, "_error.txt", SearchOption.AllDirectories).GetEnumerator();
	while (true)
	{
		try
		{
			if (!errFiles.MoveNext())
				break;
			string errFile = errFiles.Current;
			// processing
		} catch (Exception e)
		{
			log.Warn("Ignoring error finding in: " + baseDir, e);
		}
	}
