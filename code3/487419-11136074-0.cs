    System.IO.Directory.GetFileSystemEntries("C:\\Temp");
    foreach (string path in System.IO.Directory.GetFileSystemEntries("C:\\Temp"))
    {
          if (File.Exists(path))
          {
              Console.WriteLine("im a file");
          }
          else
          {
              Console.WriteLine("im a folder");
           }
     }
