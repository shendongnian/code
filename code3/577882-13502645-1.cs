    using System.IO;
    ...
    string path = ConfigurationManager.AppSettings["FolderPath"];
    string fullPath = Path.Combine(path, "filename.txt");
    if(!Directory.Exists(path))
    {
       Directory.CreateDirectory(path);
    }
    using(StreamWriter wr = new StreamWriter(fullPath, FileMode.Create))
    {
    }
