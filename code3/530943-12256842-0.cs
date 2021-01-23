    string directories = /* ... whatever ... */;
    List<string> xmlList = new List<string>();
    
    foreach (string directory in string.Split(new[] {';'}, StringSplitOptions..RemoveEmptyEntries))
    {
       string dir = directory.Trim();
       if (!dir.EndsWith(Path.DirectorySeparator))
         dir += Path.DirectorySeparator;
       xmlList.AddRange(Directory.GetFiles(dir, "*.xml"));
    }
