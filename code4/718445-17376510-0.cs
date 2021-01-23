    HashSet<string> JpegExtensions = 
        new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            { ".jpg", ".jpe", ".jpeg", ".jfi", ".jfif" }; // add others as necessary
    foreach(var fname in Directory.EnumerateFiles(pathname))
    {
        if (JpegExtensions.Contains(Path.GetExtension(fname))
        {
            Console.WriteLine(fname); // do something with the file
        }
    }
