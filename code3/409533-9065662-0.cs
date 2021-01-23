    using System.IO;
    private void CreateIfRequired(string path)
    {
      bool folderExists = Directory.Exists(Server.MapPath(path));
      if (!folderExists)
        Directory.CreateDirectory(Server.MapPath(path));
    }
