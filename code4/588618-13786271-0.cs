    IEnumerable<FileInfo> Mp3Files = new DirectoryInfo(dir).GetFiles();
    // catalog all names and their length in bytes
    IEnumerable<Mp3File> musicFiles = Mp3Files.Select(o => new Mp3File() { Name = o.Name, Size = o.Length });
    
    // concat all into one
    byte[] musicData = files.SelecMany(o => File.ReadAllBytes(o.FullName)).ToArray();
    File.WriteAllBytes("allmusic.data", musicData);
    
    byte[] GetSingleMusicFile(string name)
    {
    	// find the music file by name, and get how many bytes it is
    	int bytesToTake = musicFiles.First(o => o.Name == name).Length;
    	
    	// count all the music files BEFORE it and add up their bytes to find out how many bytes to skip
    	int bytesToSkip = musicFiles.TakeWhile(o => o.Name != name).Sum(o => o.Size);
    	
    	// skip the bytes until you get to your music file then take its bytes
    	byte[] singleMusicData = musicData.Skikp(bytesToSkip).Take(bytesToTake).ToArray();
    	return singleMusicData[]
    }
