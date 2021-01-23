    namespace Test2
    {
        internal static class MyProgram
        {
            [STAThread]
            private static void Main(string[] args)
            {
                List<Plugin> plugins = new List<Plugin>
                                           {
                                               new Plugin(@"c:\temp\file1.txt"),
                                               new Plugin(@"c:\temp\file2.txt"),
                                               new Plugin(@"c:\temp\file3.txt"),
                                           };
    
                foreach (var plugin in plugins)
                {
                    // I need StartWatch to be called only after i got OnChanged() for the previous plugin
                    plugin.StartWatch();
                    plugin.WaitHandler.WaitOne();
                }
            }
        }
    
    
        public class Plugin
        {
            private FileSystemWatcher _watcher;
            private readonly string _file;
            public AutoResetEvent WaitHandler {get;private set;} 
    
            public Plugin(string file)
            {
                _file = file;
                Console.WriteLine("Creating plugin for file {0}", _file);
                WaitHandler = new AutoResetEvent(false);
            }
    
            public void StartWatch()
            {
                Console.WriteLine("Starting watching {0}", _file);
                WaitHandler.Reset();
                FileInfo fileInfo = new FileInfo(_file);
                if (fileInfo.Directory != null)
                {
                    _watcher = new FileSystemWatcher(fileInfo.Directory.FullName, fileInfo.Name);
                    _watcher.NotifyFilter = NotifyFilters.LastWrite;
                    _watcher.Changed += OnChanged;
                    _watcher.EnableRaisingEvents = true;
                }
                // i want the main thread to be paused untill i get the OnChanged()
            }
    
            private void OnChanged(object source, FileSystemEventArgs e)
            {
                Console.WriteLine("Finished watching file {0}", _file);
                _watcher.Dispose();
    
                // once i get this event, i want the main thread to continue and to start watching the same plugin
                WaitHandler.Set();
            }
        }
    }
