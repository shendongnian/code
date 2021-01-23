        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("c:\\offTopic");
            var data = di.EnumerateDirectories()
                .Select(a => 
                    new string[] 
                    {   a.Name, 
                        "" + (a.EnumerateFiles().Count() > 0), 
                        "" + a.EnumerateFileSystemInfos().Max(b => b.LastWriteTime) 
                    });
           foreach (var x in data)
           {
               Console.WriteLine(string.Join(",", x));
           }
        }
