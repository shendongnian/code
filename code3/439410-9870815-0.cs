    private void convertFile(string filename)
    {
        // build name of output file
        string convertedFile = Path.ChangeExtension(filename, ".out");
        // open input file for reading
        FileInfo source = new FileInfo(filename);
        StreamReader srcStream = source.OpenText();
        // open output file for writing
        using (StreamWriter dstStream = File.CreateText(convertedFile))
		{
			// loop over input file
			string line;
			do
			{
				// get next line from input file
				line = srcStream.ReadLine();
				if (!Regex.IsMatch(line, @"fred=\d+"))
				{
					dstStream.WriteLine(line);
					dstStream.Flush();
				}
			} while (line != null);
		}
		
		Debug.WriteLine(string.Format("File written to: {0}", convertedFile));
    }
