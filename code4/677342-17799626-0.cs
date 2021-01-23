    public void AddToArchive(string fileToBeZipped, string zipDestination)
    {
        DirectoryInfo Di = new DirectoryInfo(zipDestination);
        StringBuilder sb_archiveFile = new StringBuilder(zipDestination + Path.DirectorySeparatorChar + Di.Name + @".7z");
        string archiveFile = sb_archiveFile.ToString();
 
        SevenZip.SevenZipCompressor compressor = new SevenZipCompressor();
        Console.WriteLine("zip destination : " + Di.Name);
        if (!File.Exists(fileToBeZipped))
        {
            Console.WriteLine("Appending {0} to Archive ", fileToBeZipped);
            compressor.CompressionMode = SevenZip.CompressionMode.Append;
        }
        else
		{
			Console.WriteLine("Creating {0} at Destination {1}....", fileToBeZipped, archiveFile);
			Console.WriteLine("CREATING:: ");
			compressor.CompressionMode = SevenZip.CompressionMode.Create;
		}
		compressor.CompressionLevel = CompressionLevel.Normal;
		compressor.CompressionMethod = CompressionMethod.Lzma;
		compressor.CompressionMode = CompressionMode.Append;
		 
		compressor.CompressDirectory(zipDestination, archiveFile);
		 
		compressor.CompressStream(streamer, streamer2);
	}
