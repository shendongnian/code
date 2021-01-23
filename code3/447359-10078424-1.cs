    public static class TestExtensions
    {
        private static Dictionary<string, string> RootPaths = new Dictionary<string, string>();
        public static void RegisterRoot(string rootKey, string rootPath)
        {
            // Omitted null checking, but should do it.
            RootPaths[rootKey] = rootPath;
        }
        public static string AddRoot(this string path, string rootKey)
        {
            return Path.Combine(RootPaths[rootKey], path);
        }
    }
