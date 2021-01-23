    void Main()
    {
        var profilePath = Environment
            .GetFolderPath(Environment.SpecialFolder.UserProfile);
        var imagePattern = "*.jpg";
        var dontLookHere = new[]
        {
            "AppData", "SomeOtherFolder"
        };
        
        var results = new List<string>();
        var searchStack = new Stack<string>();
        searchStack.Push(profilePath);    
        while(searchStack.Count > 0)
        {    
            var path = searchStack.Pop();
            var folderName = new DirectoryInfo(path).Name;
            if(dontLookHere.Any(verboten => folderName == verboten))
            {
                continue;
            }
            Console.WriteLine("Scanning path {0}", path);
            try
            {
                var images = Directory.EnumerateFiles(
                     path, 
                     imagePattern, 
                     SearchOption.TopDirectoryOnly);
                foreach(var image in images)
                {
                    Console.WriteLine("Found an image! {0}", image);
                    results.Add(image);
                }
                var subpaths = Directory.EnumerateDirectories(
                      path, 
                      "*.*", 
                      SearchOption.TopDirectoryOnly);
                foreach (var subpath in subpaths)
                {
                    searchStack.Push(subpath);
                }
            }
            catch(UnauthorizedAccessException nope)
            {
                Console.WriteLine("Can't access path: {0}", path);
            }
        }
    }
