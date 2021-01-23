    static void Main(string[] args)
    {
        var fileFinder = new FileFinder(@"c:\SomePath");
        listBox3.Items.Add(fileFinder.Files);
    }
    /// <summary>
    /// SOLID: This class is responsible for recusing a directory to return the list of files, which are 
    /// not in an predefined set of folder exclusions.
    /// </summary>
    internal class FileFinder
    {
        private readonly string _rootPath;
        private List<string> _fileNames;
        private readonly IEnumerable<string> _doNotSearchFolders = new[] { "System Volume Information", "$RECYCLE.BIN" };
        internal FileFinder(string rootPath)
        {
            _rootPath = rootPath;
        }
        internal IEnumerable<string> Files
        {
            get
            {
                if (_fileNames == null)
                {
                    _fileNames = new List<string>();
                    GetFiles(_rootPath);
                }
                return _fileNames;
            }
        }
        private void GetFiles(string path)
        {
            _fileNames.AddRange(Directory.GetFiles("*.*"));
            foreach (var recursivePath in Directory.GetDirectories(path).Where(_doNotSearchFolders.Contains))
            {
                GetFiles(recursivePath);
            }
        }
    }
