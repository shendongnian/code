    public IEnumerable<string > Foo(string path)
    {
         foreach (string file in Directory.EnumerateFiles(
            path, "*.*", SearchOption.AllDirectories))
         {
             // Add additional logic if you need here
             yield return file;
          }
    }
