    public static class DirectoryEx
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern bool PathMatchSpec(string file, string spec);
        public static IEnumerable<string> GetFilesExact(string path, string searchPattern)
        {
            var files = Directory.GetFiles(path, searchPattern).ToList();
            foreach (var file in files)
            {
                if (PathMatchSpec(file, searchPattern))
                {
                    yield return file;
                }
            }
        }
    }
