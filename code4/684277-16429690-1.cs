    public IList<string> getMusicFilesInternal(string directory)
    {
      List<string> songpaths = new List<string>();
      string[] localFiles= System.IO.Directory.GetFiles(directory);
      for(int i=0; i<localFiles.Length-1; i++) {
        if(isMusicFile(localFiles[i])) {
          songpaths.add(localFiles[i]);
        }
      }
      string[] localFolders= System.IO.Directory.GetDirectories(directory);
      for(int i=0; i<localFolder.length-1; i++) {
        songpaths.AddRange(getMusicFiles(localFolder[i]));
      }
      return songpaths;
    }
