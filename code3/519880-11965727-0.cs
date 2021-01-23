    public string FileSizeAsString(long lengthOfFile)
    {
	string[] sizes = { "bytes", "KB", "MB", "GB" };
	int j = 0;
	while (lengthOfFile > 1024 && j < sizes.Length)
	{
	    lengthOfFile = lengthOfFile / 1024;
	    j++;
	}
	return (lengthOfFile + " " + sizes[j]);
    }
