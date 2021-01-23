    /// <summary>
    /// Create the folder if not existing for a full file name
    /// </summary>
    /// <param name="filename">full path of the file</param>
    public static void CreateFolderIfNeeded(string filename) {
      string folder = System.IO.Path.GetDirectoryName(filename);
      System.IO.Directory.CreateDirectory(folder);
    }
