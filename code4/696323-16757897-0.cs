    public IEnumerable<string> Foo(string path)
    {
        var files = new List<string>();
        try
        {
          files.AddRange(Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories));
        }
        catch (Exception)
        {
           // this is bad style. You should catch more specific exceptions
        }
    
        return files;
    }
