    public static class StringExtensions
    {
        public static String PathLevel(this String path, int level)
        {
            if (path == null) throw new ArgumentException("Path must not be null", "path");
            if (level < 0) throw new ArgumentException("Level must be >= 0", "level");
            var levels = path.Split(Path.DirectorySeparatorChar);
            return levels.Length > level ? levels[level] : null;
        }
    }
