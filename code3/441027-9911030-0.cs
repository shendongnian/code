    foreach (string fl in FileListing)
    {
        // Note change in name to be clearer (IMO)
        ProjectDirectoryProcessor pjp = new ProjectDirectoryProcessor(fl);
        Thread oThread = new Thread(pjp.Execute);
        oThread.Start();
    }
...
    public class ProjectDirectoryProcessor
    {
        private readonly string rootDirectory;
        public ProjectDirectoryProcessor(string rootDirectory)
        {
            this.rootDirectory = rootDirectory;
        }
        public void Execute()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            HashSet<string> DirectoryHolding = new HashSet<string>();
            // do some work
            //foreach loop
        }
    }
