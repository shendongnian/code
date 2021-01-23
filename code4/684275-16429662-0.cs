    public ArrayList getMusicFiles(string directory, ArrayList songpaths){
      string[] localFiles= System.Io.Directory.GetFiles(rootDir);
      for(int i=0; i<localFiles.Length-1; i++) if(isMusicFile(localFiles[i]))
          songpaths.add(localFiles[i]);
      string[] localFolders= System.IO.Directory.GetDirectories(rootDir);
    for(int i=0; i<localFolder.length-1; i++) getMusicFiles(localFolder[i]);
