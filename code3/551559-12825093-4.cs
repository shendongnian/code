    public sealed class PathEntry
    {
        public string Path { get; private set; }
        public string Description { get; private set; }
        public PathEntry(string path)
          : this(path, path)
        {
        }
        public PathEntry(string path, string description)
        {
            this.Path = path;
            this.Description = description;
        }
    }
