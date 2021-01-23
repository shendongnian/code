    string[] files = System.IO.Directory.GetFiles(fullpath,"document.*");
    foreach (string f in files)
    {
       System.IO.File.Delete(f);
    }
