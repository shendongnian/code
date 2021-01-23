    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fw = new FileSystemWatcher(@"C:\temp");
            fw.Created += fileSystemWatcher_Created;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            fw.EnableRaisingEvents = true;
            Console.ReadLine();
        }
        static void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
