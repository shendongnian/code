    public IEnumerable<string> getMusicFilesInternal(string directory)
    {
      foreach (var file in System.IO.Directory.GetFiles(directory)) {
        if (isMusicFile(file)) {
          yield return file;
        }
      }
    
      foreach (var dir in System.IO.Directory.GetDirectories(directory)) {
        foreach (var musicFile in getMusicFiles(dir)) {
          yield return musicFile;
        }
      }
    }
