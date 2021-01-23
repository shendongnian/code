    using System;
    using System.IO;
    
    namespace MyDocumentsWatcher
    {
        class Program
        {
            static void Main(string[] args)
            {
                var random = new Random();
    
                var watcher =
                    new FileSystemWatcher()
                    {
                        Path = @"C:\Users\dharmatech\Documents",
                        Filter = "*.cs",
                        NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                        IncludeSubdirectories = true,
                        EnableRaisingEvents = true
                    };
                
                watcher.Changed += (s, e) =>
                    {
                        Console.WriteLine("{0} {1}", e.ChangeType, e.Name);
    
                        var path = e.FullPath;
    
                        while (true)
                        {
                            if (Path.GetDirectoryName(path) == @"C:\Users\dharmatech\Documents")
                            {
                                var tmp = Path.Combine(path, random.Next().ToString());
                                using (File.Create(tmp)) { }
                                File.Delete(tmp);
                                break;
                            }
                            else
                                path = Path.GetDirectoryName(path);
                        }
                    };
    
                Console.ReadLine();
            }
        }
    }
