    class MyClass
    {
        public WeakReference FileSystemWatcherWeakReference;
        public MyClass()
        {
            var fileToWatch = @"d:\temp\test.txt";
            var fsw = new FileSystemWatcher(
                Path.GetDirectoryName(fileToWatch),
                Path.GetFileName(fileToWatch));
            fsw.Changed += OnFileChanged;
            fsw.EnableRaisingEvents = false;
            FileSystemWatcherWeakReference = new WeakReference(fsw);
        }
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // process file... 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            GC.Collect();
            Console.WriteLine(mc.FileSystemWatcherWeakReference.IsAlive);
        }
    }
