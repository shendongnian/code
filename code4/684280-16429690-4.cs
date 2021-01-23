    public List<string> getMusicFiles(string directory) {
      var list = new List<string>();
      getMusicFiles(list, directory);
      return list;
    }
    
    private void getMusicFilesInternal(List<string> songpaths, string directory)
    {
      string[] localFiles= System.IO.Directory.GetFiles(directory);
      for(int i=0; i<localFiles.Length-1; i++) {
        if(isMusicFile(localFiles[i])) {
          songpaths.add(localFiles[i]);
        }
      }
      string[] localFolders= System.IO.Directory.GetDirectories(directory);
      for(int i=0; i<localFolder.length-1; i++) {
        getMusicFiles(songpaths, localFolder[i]);
      }
    }
