    public static class TestExtensions
    {
        private static string RootPath = @"C:\Some\Root\Path";
        public static string AddRoot(this string path)
        {
            return Path.Combine(RootPath, path);
        }
    }
