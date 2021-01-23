    public IEnumerator SearchFor(string fileExtension, DirectoryInfo at) {
      try {
        foreach (DirectoryInfo subDir in at.GetDirectories()) {
            SearchFor(fileExtension, subDir);
            foreach (FileInfo f in at.GetFiles()) {
                // test f.name for a match with fileExtension
                // if it matches...
                //   yield return f.name;
            }
        }
      } catch (UnauthroizedAccessException) { }
    }
