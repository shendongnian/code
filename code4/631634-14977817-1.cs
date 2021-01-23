    DirectoryInfo di = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());
    FileInfo[] files = di.GetFiles("*.sqlite")
                         .Where(p => p.Extension == ".sqlite").ToArray();
    foreach (FileInfo file in files)
      try
      {
        file.Attributes = FileAttributes.Normal;
        File.Delete(file.FullName);
      }
      catch { }
