	public ArrayList getMusicFiles(string directory, ArrayList data, string rootDir) {
		string[] localFiles = System.IO.Directory.GetFiles(rootDir);
		for (int i = 0; i < localFiles.Length - 1; i++) 
			if (isMusicFile(localFiles[i])) 
				songpaths.add(localFiles[i]);
		
		string[] localFolders = System.IO.Directory.GetDirectories(rootDir);
		for (int i = 0; i < localFolder.length - 1; i++) 
			data.AddRange(getMusicFiles(localFolder[i]));
        return data;
	}
