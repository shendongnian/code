    static class Program
    {
        static long position = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = System.Environment.CurrentDirectory;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "data.txt"; // or *.txt for all .txt files.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (FileStream fileStream = new FileStream("data.txt", FileMode.Open))
            {
                // Using Ron Deijkers answer, skip to the part you din't read.
                fileStream.Seek(position, SeekOrigin.End);
                for (int i = 0; i < fileStream.Length; i++)
                {
                    fileStream.ReadByte();
                }
            }
        }
    }
