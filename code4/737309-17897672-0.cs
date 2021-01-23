    System.IO.File.Move("oldfilename", "oldfilename".ToLower());
    string[] files = Directory.GetFiles(dir);
    foreach(string file in files)
    {        
        System.IO.File.Move(file, file.ToLowerInvariant());
    }
