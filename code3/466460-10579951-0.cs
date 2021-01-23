	using (var output = new FileStream(outputFile, FileMode.Append, FileAccess.Write, FileShare.Write))
	{
		foreach (var inputFile in inputFiles)
		{
			using (var input = File.OpenRead(inputFile))
			{
				input.CopyTo(output);
			}
		}
	 }
