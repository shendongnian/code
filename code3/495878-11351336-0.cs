    private static IEnumerable<string> GetFiles(string sourceFolder, string[] exts, System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.GetFiles(sourceFolder, "*.*", searchOption)
                    .Where(s=>exts.Contains(System.IO.Path.GetExtension(s), StringComparer.OrdinalIgnoreCase));
        }
