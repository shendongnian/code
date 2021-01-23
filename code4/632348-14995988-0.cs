    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Run(@"C:\Users\Hanlet\Desktop\Watcher\ConsoleApplication1\bin\Debug");  
            }
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            public static void Run(string path)
            {
                
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path =path;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.xml";
    
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
    
                watcher.EnableRaisingEvents = true;
    
                Console.WriteLine("Press \'q\' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
    
            private static void OnChanged(object source, FileSystemEventArgs e)
            {
                if(e.FullPath.IndexOf("resource.xml") > - 1)
                    Console.WriteLine("The file was: " + e.ChangeType);
            }
        }
    }
