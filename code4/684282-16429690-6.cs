    public IEnumerable<string> getMusicFiles(string directory)
    {
      string[] localFiles= System.IO.Directory.GetFiles(directory);
      for(int i=0; i<localFiles.Length-1; i++) {
        if(isMusicFile(localFiles[i])) {
          yield return localFiles[i];
        }
      }
      string[] localFolders= System.IO.Directory.GetDirectories(directory);
      for(int i=0; i<localFolder.length-1; i++) {
        foreach (var j in getMusicFiles(localFolder[i])) {
          yield return j;
        }
      }
    }
